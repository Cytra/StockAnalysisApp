using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core.DTOs
{
    public class StockListItem
    {
        public string symbol { get; set; }
        public string name { get; set; }
        public double price { get; set; }
    }
}
