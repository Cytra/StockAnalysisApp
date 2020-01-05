using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.UIWPF.ViewModels
{
    public class CompanyKeyMetricsViewModel
    {
        private readonly ICompanyKeyMetricsFacade _companyKeyMetricsFacade;

        public CompanyKeyMetricsViewModel(ICompanyKeyMetricsFacade companyKeyMetricsFacade)
        {
            _companyKeyMetricsFacade = companyKeyMetricsFacade ?? throw new ArgumentNullException(nameof(companyKeyMetricsFacade));
            _companyKeyMetricsFacade.GetStockWithKeyMetrics(new Stock() { Symbol = "AAPL" });
        }
    }
}
