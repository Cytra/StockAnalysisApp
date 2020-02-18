using StockAnalysisApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.Data.Repositories
{
    public interface IStockRepository
    {
        Task SaveStocks(List<Stock> stocks);
        Task AddStock(Stock stock);
        Task UpdateStock(Stock stock, int id);
        Task<List<Stock>> GetStocks();
    }
}
