﻿using Newtonsoft.Json;
using StockAnalysisApp.Core.DTOs;
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
    public class StockListService : IStockListService
    {
        private const string _apiUrl = "https://financialmodelingprep.com/api/v3/company/stock/list";
        
        private readonly IWindowsLogger _logger;

        public StockListService(IWindowsLogger logger)
        {
            _logger = logger;
        }
        public async Task<SymbolsList> GetStockList()
        {
            SymbolsList result = null; 
            try
            {
                _logger.WriteInformation("Getting Stock List");
                using (var httpClient = new HttpClient())
                {
                    using (var request = new HttpRequestMessage(new HttpMethod("GET"), _apiUrl))
                    {
                        request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");

                        var response = await httpClient.SendAsync(request);
                        if (response.IsSuccessStatusCode)
                        {
                            var jsonString = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<SymbolsList>(jsonString);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.WriteError("Error calling Stock list APi", ex);
            }
            _logger.WriteInformation("Received Stock List");
            return result;
        }

        
    }
}
