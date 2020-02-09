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
        public double StockPrice { get; set; }
        public double DCF { get; set; }

        public decimal Diff
        {
            get
            {
                if (StockPrice == null)
                {
                    return 0;
                }
                if (DCF == null)
                {
                    return 0;
                }
                if (DCF == 0)
                {
                    return 0;
                }
                if (StockPrice == 0)
                {
                    return 0;
                }

                if (double.IsInfinity(DCF))
                {
                    return (decimal)(StockPrice * 100 / 99999999);
                }
                return (decimal)(StockPrice * 100 / DCF);
            }
        }
    }
}
