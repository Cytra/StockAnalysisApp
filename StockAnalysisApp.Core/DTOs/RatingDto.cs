using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core.DTOs
{
    public class RatingDto
    {
        public int Score { get; set; }
        public string Rating { get; set; }
        public string Recommendation { get; set; }
    }
}
