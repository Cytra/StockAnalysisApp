using StockAnalysisApp.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.Services.Interfaces
{
    public interface IStockListService
    {
        Task<SymbolsList> GetStockList();
    }
}
