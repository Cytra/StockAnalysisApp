using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core.Model
{
    public class Dcf
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public DateTime Date { get; set; }
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
