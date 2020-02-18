using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core.DTOs
{
    public class RatingDetailsDto
    {
        [JsonProperty(PropertyName = "P/B")]
        public RatingDetailDto PB { get; set; }
        [JsonProperty(PropertyName = "ROA")]
        public RatingDetailDto ROA { get; set; }
        [JsonProperty(PropertyName = "DCF")]
        public RatingDetailDto DCF { get; set; }
        [JsonProperty(PropertyName = "P/E")]
        public RatingDetailDto PE { get; set; }
        [JsonProperty(PropertyName = "ROE")]
        public RatingDetailDto ROE { get; set; }
        [JsonProperty(PropertyName = "D/E")]
        public RatingDetailDto DE { get; set; }
    }

    public class RatingDetailDto
    {
        public string Score { get; set; }
        public string Recommendation { get; set; }
    }
}
