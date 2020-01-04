using StockAnalysisApp.Core.DTOs;
using StockAnalysisApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.Services.Interfaces
{
    public interface IDCFService
    {
        Task<DcfDto> GetDcf(string stock);
        Task<List<DcfDto>> GetDcfList(List<Stock> stocks);
    }
}
