
using StockAnalysisApp.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StockAnalysisApp.Data.Repositories
{
    public interface IDcfRepository
    {
        Task<List<DcfDto>> GetDcfDto();
        void AddDcf(DcfDto dto);
        void AddDcfList(List<DcfDto> dcfs);
    }
}
