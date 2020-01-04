using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Services.API
{
    public class StockSymbolService : IStockSymbolService
    {
        public List<string> GetStockListString(List<Stock> stocks, int frequancy)
        {
            var result = new List<string>();
            var currentStockList = string.Empty;
            foreach (var stock in stocks)
            {
                if (stocks.IndexOf(stock) % frequancy == 0)
                {
                    if (!string.IsNullOrWhiteSpace(currentStockList))
                    {
                        result.Add(currentStockList);
                        currentStockList = string.Empty;
                    }
                };

                if (!string.IsNullOrWhiteSpace(stock.Symbol) && ValidTicker(stock.Symbol))
                {
                    if (currentStockList.Length == 0)
                    {
                        currentStockList += stock.Symbol;
                    }
                    else
                    {
                        currentStockList += "," + stock.Symbol;
                    }
                }
            }
            return result;
        }

        private bool ValidTicker(string ticker)
        {
            var invalidStocks = new List<string>()
            {
                "CSRA", "BUFF", "MITL", "TAHO",
                "STO", "QM", "CGI", "MTU", "VR",
                "LNCE", "DYN", "LOXO", "BWP", "CALD",
                "FAC", "NSU", "LFIN"
            };

            if (invalidStocks.Contains(ticker))
            {
                return false;
            }
            return true;
        }
    }
}
