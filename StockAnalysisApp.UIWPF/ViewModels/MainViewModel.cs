﻿using AutoMapper;
using Caliburn.Micro;
using StockAnalysisApp.Core.DTOs;
using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Logger.Loggers;
using StockAnalysisApp.Services.Interfaces;
using StockAnalysisApp.UIWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockAnalysisApp.UIWPF.Views
{
    public class MainViewModel : PropertyChangedBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IStockListService _stockListService;
        private readonly IMapper _mapper;
        private readonly IWindowsLogger _logger;
        private readonly IDcfFacade _dCFfacade;
        private readonly CompanyKeyMetricsViewModel _companyKeyMetricsViewModel;

        public SymbolsList SymbolList { get; set; }

        private List<Stock> _stocks;

        public List<Stock> Stocks
        {
            get { return _stocks; }
            set
            {
                _stocks = value;
                OnPropertyChanged(nameof(Stocks));
            }
        }

        private List<Stock> _sortedStocks;

        public List<Stock> SortedStocks
        {
            get { return _sortedStocks; }
            set
            {
                _sortedStocks = value;
                OnPropertyChanged(nameof(SortedStocks));
            }
        }

        private Stock _selectedStock;

        public Stock SelectedStock
        {
            get { return _selectedStock; }
            set
            {
                _selectedStock = value;
                OnPropertyChanged(nameof(SelectedStock));
            }
        }

        private string _stockTicker;
        public string StockTicker
        {
            get { return _stockTicker; }
            set
            {
                _stockTicker = value;
                OnPropertyChanged(nameof(StockTicker));
                SortList(value);
            }
        }

        public DCFStrategyViewModel _dCFStrategyViewModel { get; set; }
        public ICommand GetDCF { get; set; }
        public ICommand GetCompanyKeyMetrics { get; set; }
        public ICommand Prepare { get; set; }

        private bool _isActive = false;

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                _isActive = value;
                OnPropertyChanged(nameof(IsActive));
            }
        }

        private string _dataGridVisibility = "Visible";

        public string DataGridVisibility
        {
            get { return _dataGridVisibility; }
            set
            {
                _dataGridVisibility = value;
                OnPropertyChanged(nameof(DataGridVisibility));
            }
        }


        public MainViewModel(
            IStockListService stockListService,
            IMapper mapper,
            IWindowsLogger logger,
            IDcfFacade dCFfacade,
            DCFStrategyViewModel dCFStrategyViewModel,
            CompanyKeyMetricsViewModel companyKeyMetricsViewModel
            )
        {
            _stockListService = stockListService ?? throw new ArgumentNullException(nameof(stockListService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dCFfacade = dCFfacade ?? throw new ArgumentNullException(nameof(dCFfacade));
            _dCFStrategyViewModel = dCFStrategyViewModel ?? throw new ArgumentNullException(nameof(dCFStrategyViewModel));
            _companyKeyMetricsViewModel = companyKeyMetricsViewModel ?? throw new ArgumentNullException(nameof(companyKeyMetricsViewModel));
            GetDCF = new DelegateCommand(ExecuteGetDCF);
            GetCompanyKeyMetrics = new DelegateCommand(ExcecuteGetCompanyKeyMetrics);
            Prepare = new DelegateCommand(ExcecutePrepare);
            InitializeData();
        }

        private void ExcecutePrepare()
        {
            Task.Run(async () =>
            {
                try
                {
                    SymbolList = await _stockListService.GetStockList();
                    await _dCFfacade.GetDcfListWithBulkOrder(Stocks);
                    ToggleVisibility(true);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    ToggleVisibility(false);
                }
            });
        }

        private void ExcecuteGetCompanyKeyMetrics()
        {
            var companyKeyMetrics = new CompanyKeyMetricsView();
            companyKeyMetrics.DataContext = _companyKeyMetricsViewModel;
            companyKeyMetrics.Show();
        }

        private void ExecuteGetDCF()
        {
            var dcfStrategyView = new DCFStrategyView();
            dcfStrategyView.DataContext = _dCFStrategyViewModel;
            dcfStrategyView.Show();
        }

        private void InitializeData()
        {
            Task.Run(async () =>
            {
                try
                {
                    SymbolList = await _stockListService.GetStockList();
                    Stocks = _mapper.Map<List<Stock>>(SymbolList.symbolsList);
                    SortedStocks = Stocks;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }

        private void SortList(string value)
        {
            SortedStocks = Stocks
                .Where(x => x.Name != null)
                .Where(x => x.Symbol != null)
                .Where(x => x.Symbol.ToUpper().Contains(value.ToUpper()) || x.Name.ToUpper().Contains(value.ToUpper()))
                .ToList();
        }

        private void ToggleVisibility(bool spinning)
        {
            if (spinning)
            {
                IsActive = true;
                DataGridVisibility = "Hidden";
            }
            else
            {
                IsActive = false;
                DataGridVisibility = "Visible";
            }
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
