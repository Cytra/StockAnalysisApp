using AutoMapper;
using Caliburn.Micro;
using StockAnalysisApp.Core.DTOs;
using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Data.Repositories;
using StockAnalysisApp.Logger.Loggers;
using StockAnalysisApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StockAnalysisApp.UIWPF.ViewModels
{
    public class DCFStrategyViewModel : PropertyChangedBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly IStockListService _stockListService;
        private readonly IMapper _mapper;
        private readonly IWindowsLogger _logger;
        private readonly IDcfFacade _dCFfacade;
        private readonly IDcfRepository _dcfRepository;

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

        private List<DcfDto> _sorteddcfDtos;
        public List<DcfDto> SortedDcfDtos
        {
            get { return _sorteddcfDtos; }
            set
            {
                _sorteddcfDtos = value;
                OnPropertyChanged(nameof(SortedDcfDtos));
            }
        }

        private DcfDto _selectedDcfDto;
        public DcfDto SelectedDcfDto
        {
            get { return _selectedDcfDto; }
            set
            {
                _selectedDcfDto = value;
                OnPropertyChanged(nameof(SelectedDcfDto));
            }
        }

        private List<DcfDto> _dcfDtos;
        public List<DcfDto> DcfDtos
        {
            get { return _dcfDtos; }
            set
            {
                _dcfDtos = value;
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
                SortList();
            }
        }

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

        public List<DateTime> DateList
        {
            get
            {
                if (DcfDtos != null)
                {
                    return DcfDtos.Select(x => x.date).Distinct().ToList();
                }
                return null;
            }
        }

        private DateTime _selectedDate;
        public DateTime SelectedDate
        {
            get { return _selectedDate; }
            set
            {
                _selectedDate = value;
                OnPropertyChanged(nameof(SelectedDate));
                SortList();
            }
        }

        public ICommand GetNewDCF { get; set; }

        public DCFStrategyViewModel(
            IStockListService stockListService,
            IMapper mapper,
            IWindowsLogger logger,
            IDcfFacade dCFfacade,
            IDcfRepository dcfRepository
            )
        {

            _stockListService = stockListService ?? throw new ArgumentNullException(nameof(stockListService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dCFfacade = dCFfacade ?? throw new ArgumentNullException(nameof(dCFfacade));
            _dcfRepository = dcfRepository ?? throw new ArgumentNullException(nameof(dcfRepository));
            GetNewDCF = new DelegateCommand(ExcecuteGetNewDCF);
            InitializeData();
        }

        private void ExcecuteGetNewDCF()
        {

            Task.Run(async () =>
            {
                try
                {
                    ToggleVisibility(true);
                    SymbolList = await _stockListService.GetStockList();
                    Stocks = _mapper.Map<List<Stock>>(SymbolList.symbolsList);
                    await _dCFfacade.GetDcfListWithBulkOrder(Stocks);
                    DcfDtos = await _dcfRepository.GetDcfDto();
                    SortedDcfDtos = DcfDtos;
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

        private void InitializeData()
        {
            Task.Run(async () =>
            {
                DcfDtos = await _dcfRepository.GetDcfDto();
                SortedDcfDtos = DcfDtos;
            });
        }

        private void SortList()
        {

            if (string.IsNullOrEmpty(StockTicker))
            {
                SortedDcfDtos = DcfDtos;
            }

            if(DcfDtos != null && !string.IsNullOrEmpty(StockTicker))
            {
                SortedDcfDtos = DcfDtos
                .Where(x => x.symbol.ToUpper().Contains(StockTicker.ToUpper()))
                .ToList();
            }

            if (SelectedDate != null)
            {
                SortedDcfDtos = SortedDcfDtos.Where(x => x.date == SelectedDate).ToList();
            }
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
