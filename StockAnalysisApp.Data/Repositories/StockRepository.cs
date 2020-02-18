using Microsoft.EntityFrameworkCore;
using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Data.DbContexts;
using StockAnalysisApp.Logger.Loggers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.Data.Repositories
{
    public class StockRepository : IStockRepository, IDisposable
    {
        public readonly StockDbContext _context;
        private readonly IWindowsLogger _logger;
        public StockRepository(StockDbContext context, IWindowsLogger logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task SaveStocks(List<Stock> stocks)
        {
            try
            {
                foreach (var stock in stocks)
                {
                    var existingStock = _context.Stocks.FirstOrDefault(x => x.Symbol == stock.Symbol);
                    if (existingStock == null)
                    {
                        ValidateStockDcf(stock);
                        _logger.WriteInformation($"Saving stock {stocks.IndexOf(stock)} / {stocks.Count} : {stock.Symbol}");
                        await AddStock(stock);
                    } else
                    {
                        ValidateStockDcf(stock);
                        _logger.WriteInformation($"SUpdating stock {stocks.IndexOf(stock)} / {stocks.Count} : {stock.Symbol}");
                        await UpdateStock(stock, existingStock.Id);
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.WriteError("Error saving DCF list to DB", ex);
            }
            _logger.WriteInformation("Saved data to DB");
        }

        private void ValidateStockDcf(Stock stock)
        {
            if (!double.IsNaN(stock.Dcf.DCF) && !double.IsNaN(stock.Dcf.StockPrice))
            {
                if (double.IsInfinity(stock.Dcf.DCF))
                {
                    stock.Dcf.DCF = 999999999;
                }
            }
        }

        public async Task AddStock(Stock stock)
        {
            try
            {
                _context.Stocks.Add(stock);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.Data.Add(stock.Id, stock);
                _logger.WriteError("Error saving Stock list to DB", ex);
            }
        }

        public async Task UpdateStock(Stock stock, int id)
        {
            try
            {
                stock.Id = id;
                _context.Entry(await _context.Stocks.FirstOrDefaultAsync(x => x.Symbol == stock.Symbol)).CurrentValues.SetValues(stock);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                ex.Data.Add(stock.Id, stock);
                _logger.WriteError("Error updating Stock list to DB", ex);
            }
        }

        public async Task<List<Stock>> GetStocks()
        {
            return await _context.Stocks.ToListAsync();
        }

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
