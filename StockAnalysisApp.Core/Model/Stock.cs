using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core.Model
{
    public class Stock
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public double DCF { get; set; }
        public double Diff
        {
            get
            {
                if (Price == 0)
                {
                    return 0;
                }
                return (double)(DCF / Price * 100);
            }
        }
    }
}
