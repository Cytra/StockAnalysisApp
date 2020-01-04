using Newtonsoft.Json;
using StockAnalysisApp.Core.DTOs;
using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Logger.Loggers;
using StockAnalysisApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StockAnalysisApp.Services.API
{
    public class DCFService : IDCFService
    {
        private const string _dcfUrl = "https://financialmodelingprep.com/api/v3/company/discounted-cash-flow/";
        private readonly IWindowsLogger _logger;
        private readonly IStockSymbolService _symbolService;

        public DCFService(IWindowsLogger logger, IStockSymbolService symbolService)
        {
            _logger = logger;
            _symbolService = symbolService;
        }
        public async Task<DcfDto> GetDcf(string stock)
        {
            DcfDto result = null;
            try
            {
                _logger.WriteInformation("Getting DCF List");
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), _dcfUrl + stock))
                    {
                        request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");

                        _logger.WriteInformation($"Getting {stock} DCF");
                        var response = await httpClient.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<DcfDto>(jsonString);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.WriteError("Error calling DCF API", ex);
            }
            _logger.WriteInformation("Received DCF");
            return result;
        }

        public async Task<List<DcfDto>> GetDcfList(List<Stock> stocks)
        {
            List<DcfDto> result = new List<DcfDto>();
            try
            {
                _logger.WriteInformation("Getting DCF List");
                using (var httpClient = new HttpClient())
                {
                    var stockListString = _symbolService.GetStockListString(stocks, 15);
                    foreach(var stockListItem in stockListString)
                    {
                        using (var request = new HttpRequestMessage(new HttpMethod("GET"), _dcfUrl + stockListItem))
                        {
                            request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");

                            _logger.WriteInformation($"Getting DCF Items {stockListString.IndexOf(stockListItem)} / {stockListString.Count} : {stockListItem}");
                            var response = await httpClient.SendAsync(request);
                            if (response.IsSuccessStatusCode)
                            {
                                var jsonString = await response.Content.ReadAsStringAsync();
                                var responseResult = JsonConvert.DeserializeObject<DcfDtoList>(jsonString);
                                _logger.WriteInformation($"Received {responseResult.DCFList.Count}");
                                foreach (var responseResultitem in responseResult.DCFList)
                                {
                                    result.Add(responseResultitem);
                                }
                            } else
                            {
                                throw new Exception($"Failed http call + {stockListItem}");
                            }
                        }
                    }
 
                }
            }
            catch (Exception ex)
            {
                _logger.WriteError("Error calling DCF API", ex);
            }
            _logger.WriteInformation("Received DCF");
            return result;
        }
    }
}
