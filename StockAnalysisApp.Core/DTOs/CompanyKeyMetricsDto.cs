using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core.DTOs
{
    public class CompanyKeyMetricsDto
    {
        public string symbol { get; set; }
        public List<CompanyKeyMetricsMetricsDto> metrics { get; set; }
    }
}
