using StockAnalysisApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.Data.Repositories
{
    public interface IStockRepoFacade
    {
        Task SaveStocks(List<Stock> stocks);
        Task<List<Stock>> GetStocks();
    }
}
