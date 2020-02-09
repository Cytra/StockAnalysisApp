using StockAnalysisApp.Core.DTOs;
using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Data.Repositories;
using StockAnalysisApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.Services.ApiFacade
{
    public class DcfFacade : IDcfFacade
    {
        private readonly IDcfRepository _dcfRepository;
        private readonly IDCFService _dcfService;

        public DcfFacade(
            IDcfRepository dcfRepository,
            IDCFService dcfService
            )
        {
            _dcfRepository = dcfRepository ?? throw new ArgumentNullException(nameof(dcfRepository));
            _dcfService = dcfService ?? throw new ArgumentNullException(nameof(dcfService)); ;
        }

        public async Task<List<DcfDto>> GetDcfList(List<Stock> stocks)
        {
            throw new NotImplementedException();
        }

        public async Task<List<DcfDto>> GetDcfListWithBulkOrder(List<Stock> stocks)
        {
            stocks = await RemoreDcfInRepo(stocks);
            var result = await _dcfService.GetDcfList(stocks);
            _dcfRepository.AddDcfList(result);
            return result;
        }

        public async Task<List<Stock>> RemoreDcfInRepo(List<Stock> stocks)
        {
            var dcfFromRepo = await _dcfRepository.GetDcfDto();
            var dcfFromRepoStrings = dcfFromRepo.FindAll(x => x.date == DateTime.Today).Select(x => x.symbol).Distinct().ToList();
            foreach (var dcf in dcfFromRepoStrings)
            {
                stocks.RemoveAll(x => x.Symbol == dcf);
            }
            return stocks;
        }
    }
}
