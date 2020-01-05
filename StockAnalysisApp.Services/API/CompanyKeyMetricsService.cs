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
    public class CompanyKeyMetricsService : ICompanyKeyMetricsService
    {
        private const string _dcfUrl = "https://financialmodelingprep.com/api/v3/company-key-metrics/";
        private readonly IWindowsLogger _logger;

        public CompanyKeyMetricsService(
            IWindowsLogger logger
            )
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task<CompanyKeyMetricsDto> GetKeyMetrics(string stock)
        {
            CompanyKeyMetricsDto result = null;
            try
            {
                _logger.WriteInformation("Getting Company Key Metrics List");
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), _dcfUrl + stock))
                    {
                        request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");

                        _logger.WriteInformation($"Getting {stock} Company Key Metric");
                        var response = await httpClient.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<CompanyKeyMetricsDto>(jsonString);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.WriteError("Error calling Company Key Metric API", ex);
            }
            _logger.WriteInformation("Received Company Key Metrics");
            return result;
        }

        public Task<CompanyKeyMetricsDtoList> GetKeyMetricsList(List<Stock> stocks)
        {
            throw new NotImplementedException();
        }
    }
}
