using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core.DTOs
{
    public class DcfDto
    {
        public int Id { get; set; }
        public string symbol { get; set; }
        public DateTime date { get; set; }
        [JsonProperty(PropertyName = "Stock Price")]
        public double? StockPrice { get; set; }
        public double? DCF { get; set; }

        public double? Diff
        {
            get
            {
                if (DCF == null)
                {
                    return null;
                }
                if (StockPrice == null)
                {
                    return null;
                }
                if (DCF == 0)
                {
                    return null;
                }
                return (double)(StockPrice * 100 / DCF);
            }
        }
    }
}
