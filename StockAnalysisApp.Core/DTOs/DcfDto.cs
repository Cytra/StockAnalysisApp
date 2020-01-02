using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core.DTOs
{
    public class DcfDto
    {
        public string symbol { get; set; }
        public DateTime date { get; set; }
        [JsonProperty(PropertyName = "Stock Price")]
        public double? StockPrice { get; set; }
        public double? DCF { get; set; }
    }
}
