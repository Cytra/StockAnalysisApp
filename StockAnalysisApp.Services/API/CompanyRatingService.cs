using Newtonsoft.Json;
using StockAnalysisApp.Core.DTOs;
using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Logger.Loggers;
using StockAnalysisApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.Services.API
{
    public class CompanyRatingService : ICompanyRatingService
    {

        private const string _companyRatingUrl = "https://financialmodelingprep.com/api/v3/company/rating/";
        private readonly IWindowsLogger _logger;
        private readonly IStockSymbolService _symbolService;

        public CompanyRatingService(
            IWindowsLogger logger,
            IStockSymbolService symbolService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _symbolService = symbolService ?? throw new ArgumentNullException(nameof(symbolService));
        }
        public async Task<List<CompanyRatingDto>> GetCompanyRatingList(List<Stock> stocks)
        {
            List<CompanyRatingDto> result = new List<CompanyRatingDto>();
            try
            {
                _logger.WriteInformation("Getting Company Rating List");
                using (var httpClient = new HttpClient())
                {
                    var stockListString = _symbolService.GetStockListString(stocks, 3);
                    foreach (var stockListItem in stockListString)
                    {
                        using (var request = new HttpRequestMessage(new HttpMethod("GET"), _companyRatingUrl + stockListItem))
                        {
                            request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");

                            _logger.WriteInformation($"Getting DCF Items {stockListString.IndexOf(stockListItem)} / {stockListString.Count} : {stockListItem}");
                            var response = await httpClient.SendAsync(request);
                            if (response.IsSuccessStatusCode)
                            {
                                var jsonString = await response.Content.ReadAsStringAsync();
                                var responseResults = JsonConvert.DeserializeObject<CompanyRatingListDto>(jsonString);
                                foreach(var responseResult in responseResults.CompaniesRating)
                                {
                                    result.Add(responseResult);
                                }
                            }
                            else
                            {
                                throw new Exception($"Failed http call + {stockListItem}");
                            }
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                _logger.WriteError("Error calling Company Rating API", ex);
            }
            _logger.WriteInformation("Received Company Rating");
            return result;
        }
    }
}
