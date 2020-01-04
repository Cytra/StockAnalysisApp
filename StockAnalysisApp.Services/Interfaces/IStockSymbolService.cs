using StockAnalysisApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Services.Interfaces
{
    public interface IStockSymbolService
    {
        List<string> GetStockListString(List<Stock> stocks, int frequancy);
    }
}
