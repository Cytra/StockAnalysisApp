using StockAnalysisApp.Core.DTOs;
using StockAnalysisApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.Services.Interfaces
{
    public interface IDcfFacade
    {
        Task<List<Stock>> RemoreDcfInRepo(List<Stock> stocks);
        Task<List<Stock>> GetDcfListWithBulkOrder(List<Stock> stocks);
    }
}
