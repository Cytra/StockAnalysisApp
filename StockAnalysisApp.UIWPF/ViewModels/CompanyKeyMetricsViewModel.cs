using Caliburn.Micro;
using StockAnalysisApp.Core.Model;
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
    public class CompanyKeyMetricsViewModel : PropertyChangedBase, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private readonly ICompanyKeyMetricsFacade _companyKeyMetricsFacade;

        private string _stockTicker;

        public string StockTicker
        {
            get { return _stockTicker; }
            set
            {
                _stockTicker = value;
                OnPropertyChanged(nameof(StockTicker));
            }
        }

        private Stock _stockKeyMetrics;

        public Stock StockKeyMetrics
        {
            get { return _stockKeyMetrics; }
            set
            {
                _stockKeyMetrics = value;
                OnPropertyChanged(nameof(StockKeyMetrics));
            }
        }


        public ICommand Prepare { get; set; }

        public CompanyKeyMetricsViewModel(ICompanyKeyMetricsFacade companyKeyMetricsFacade)
        {
            _companyKeyMetricsFacade = companyKeyMetricsFacade ?? throw new ArgumentNullException(nameof(companyKeyMetricsFacade));
            Prepare = new DelegateCommand(ExcecutePrepare, CanExcecutePrepare);
        }

        private bool CanExcecutePrepare()
        {
            if (!string.IsNullOrWhiteSpace(StockTicker))
            {
                return true;
            }
            return false;
        }

        private void ExcecutePrepare()
        {
            Task.Run(async () =>
            {
                StockKeyMetrics = await _companyKeyMetricsFacade.GetStockWithKeyMetrics(new Stock() { Symbol = StockTicker });
            });
            
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
