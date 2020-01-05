using StockAnalysisApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.Services.Interfaces
{
    public interface ICompanyKeyMetricsFacade
    {
        Task<Stock> GetStockWithKeyMetrics(Stock stock);
    }
}
