using AutoMapper;
using Caliburn.Micro;
using StockAnalysisApp.Core.DTOs;
using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Logger.Loggers;
using StockAnalysisApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
        public ICommand GetDCF { get; set; }

        public MainViewModel(IStockListService stockListService, IMapper mapper, IWindowsLogger logger)
        {
            _stockListService = stockListService ?? throw new ArgumentNullException(nameof(stockListService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            GetDCF = new DelegateCommand(ExecuteGetDCF);
            InitializeData();
        }

        private void ExecuteGetDCF()
        {
            Task.Run(async () =>
            {
                var dcfDto = await _stockListService.GetDcf(SelectedStock.Symbol);
                SelectedStock = _mapper.Map<DcfDto,Stock>(dcfDto, SelectedStock);
            });
        }

        private void InitializeData()
        {
            Task.Run(async () =>
            {
                try
                {
                    SymbolList = await _stockListService.GetStockList();
                    Stocks = _mapper.Map<List<Stock>>(SymbolList.symbolsList);
                    var stocksWithDcf = new List<Stock>();
                    foreach (var stock in Stocks)
                    {
                        if (Stocks.IndexOf(stock) > 100) break;
                        var stockDcf = await _stockListService.GetDcf(stock.Symbol);
                        _logger.WriteInformation(Stocks.IndexOf(stock).ToString());
                        var stockWithDcf = _mapper.Map<DcfDto, Stock>(stockDcf, stock);
                        if(stockWithDcf != null){
                            stocksWithDcf.Add(stockWithDcf);
                        }
                        
                    }
                    SortedStocks = stocksWithDcf;
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
                .Where(x => x.Symbol.ToUpper().Contains(value.ToUpper()) || x.Name.ToUpper().Contains(value.ToUpper()))
                .ToList();
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
