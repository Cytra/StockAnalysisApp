using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core.Model
{
    public class StockRating
    {
        public int Id { get; set; }
        public int StockId { get; set; }
        public int Score { get; set; }
        public string Rating { get; set; }
        public string Recommendation { get; set; }
    }
}
