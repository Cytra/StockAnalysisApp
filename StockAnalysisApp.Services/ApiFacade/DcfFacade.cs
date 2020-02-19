using AutoMapper;
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
        private readonly IMapper _mapper;

        public DcfFacade(
            IDcfRepository dcfRepository,
            IDCFService dcfService,
            IMapper mapper
            )
        {
            _dcfRepository = dcfRepository ?? throw new ArgumentNullException(nameof(dcfRepository));
            _dcfService = dcfService ?? throw new ArgumentNullException(nameof(dcfService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public async Task<List<Stock>> GetDcfListWithBulkOrder(List<Stock> stocks)
        {

            //stocks = await RemoreDcfInRepo(stocks);
            var dcfs = await _dcfService.GetDcfList(stocks);
            foreach(var stock in stocks)
            {
                var dcf = dcfs.FirstOrDefault(x => x.Symbol.ToLower() == stock.Symbol.ToLower());
                if (dcf != null)
                {
                    stock.Dcf = _mapper.Map<Dcf>(dcf);
                }
            }
            return stocks;
        }


        public async Task<List<Stock>> RemoreDcfInRepo(List<Stock> stocks)
        {
            var dcfFromRepo = await _dcfRepository.GetDcfDto();
            var dcfFromRepoStrings = dcfFromRepo.FindAll(x => x.Date == DateTime.Today).Select(x => x.Symbol).Distinct().ToList();
            foreach (var dcf in dcfFromRepoStrings)
            {
                stocks.RemoveAll(x => x.Symbol == dcf);
            }
            return stocks;
        }
    }
}
