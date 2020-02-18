using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core.DTOs
{
    public class DcfDto
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public DateTime Date { get; set; }
        [JsonProperty(PropertyName = "Stock Price")]
        public double StockPrice { get; set; }
        public double DCF { get; set; }
    }
}
