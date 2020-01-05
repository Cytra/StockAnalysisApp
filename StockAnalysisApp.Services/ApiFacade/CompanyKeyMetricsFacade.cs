using AutoMapper;
using StockAnalysisApp.Core.DTOs;
using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.Services.ApiFacade
{
    public class CompanyKeyMetricsFacade : ICompanyKeyMetricsFacade
    {
        private readonly ICompanyKeyMetricsService _companyKeyMetricsService;
        private readonly IMapper _mapper;

        public CompanyKeyMetricsFacade(
            ICompanyKeyMetricsService companyKeyMetricsService,
            IMapper mapper)
        {
            _companyKeyMetricsService = companyKeyMetricsService  ?? throw new ArgumentNullException(nameof(companyKeyMetricsService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Stock> GetStockWithKeyMetrics(Stock stock)
        {
            var companyKeyMetricsDtos = await _companyKeyMetricsService.GetKeyMetrics(stock.Symbol);
            _mapper.Map<CompanyKeyMetricsDto, Stock>(companyKeyMetricsDtos, stock);
            return stock;
        }
    }
}
