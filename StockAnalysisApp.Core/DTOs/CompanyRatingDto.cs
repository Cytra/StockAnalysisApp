using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core.DTOs
{
    public class CompanyRatingDto
    {
        public string Symbol { get; set; }
        public RatingDto Rating { get; set; }
        public RatingDetailsDto RatingDetails { get; set; }
    }
}
