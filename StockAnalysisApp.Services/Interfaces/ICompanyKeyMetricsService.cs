using StockAnalysisApp.Core.DTOs;
using StockAnalysisApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.Services.Interfaces
{
    public interface ICompanyKeyMetricsService
    {
        Task<CompanyKeyMetricsDto> GetKeyMetrics(string stock);
        Task<CompanyKeyMetricsDtoList> GetKeyMetricsList(List<Stock> stocks);
    }
}
