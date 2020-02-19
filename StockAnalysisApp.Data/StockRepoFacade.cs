using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Data.Repositories;
using StockAnalysisApp.Logger.Loggers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.Data
{
    public class StockRepoFacade : IStockRepoFacade
    {
        private readonly IStockRepository _stockRepository;
        private readonly IWindowsLogger _logger;

        public StockRepoFacade(IStockRepository stockRepository, IWindowsLogger logger)
        {
            _stockRepository = stockRepository ?? throw new ArgumentNullException(nameof(stockRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<Stock>> GetStocks()
        {
            return await _stockRepository.GetStocks();
        }

        public async Task SaveStocks(List<Stock> stocks)
        {
            var listOfStockLists = SplitStockList(stocks, 100);
            foreach(var stockList in listOfStockLists)
            {
                _logger.WriteInformation($"Saving stocks {listOfStockLists.IndexOf(stockList)} / {listOfStockLists.Count}");
                await _stockRepository.SaveStocks(stockList);
            }
        }

        private List<List<Stock>> SplitStockList(List<Stock> stocks, int frequancy)
        {
            var result = new List<List<Stock>>();
            var stockList = new List<Stock>();
            foreach (var stock in stocks)
            {
                stockList.Add(stock);
                if(stocks.IndexOf(stock) % frequancy == 0)
                {
                    result.Add(stockList);
                    stockList = new List<Stock>();
                }
            }
            result.Add(stockList);
            return result;
        }
    }
}
