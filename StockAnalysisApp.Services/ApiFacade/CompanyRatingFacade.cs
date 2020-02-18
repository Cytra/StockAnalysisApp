using AutoMapper;
using StockAnalysisApp.Core.DTOs;
using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.Services.ApiFacade
{
    public class CompanyRatingFacade : ICompanyRatingFacade
    {
        private readonly ICompanyRatingService _companyRatingService;
        private readonly IMapper _mapper;

        public CompanyRatingFacade(ICompanyRatingService companyRatingService, IMapper mapper)
        {
            _companyRatingService = companyRatingService ?? throw new ArgumentNullException(nameof(companyRatingService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<Stock>> GetStocksWithRatings(List<Stock> stocks)
        {
            var companieRatings = await _companyRatingService.GetCompanyRatingList(stocks);
            foreach(var stock in stocks)
            {
                var companieRating = companieRatings.FirstOrDefault(x => x.Symbol.ToLower() == stock.Symbol.ToLower());
                if(companieRating != null)
                {
                    stock.StockRating = _mapper.Map<StockRating>(companieRating.Rating);
                }
            }
            return stocks;
        }

    }
}
