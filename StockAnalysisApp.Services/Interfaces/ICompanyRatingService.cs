using StockAnalysisApp.Core.DTOs;
using StockAnalysisApp.Core.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAnalysisApp.Services.Interfaces
{
    public interface ICompanyRatingService
    {
        Task<List<CompanyRatingDto>> GetCompanyRatingList(List<Stock> stocks);
    }
}
