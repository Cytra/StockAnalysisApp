using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core.Model
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; } = DateTime.Today;
        public List<StockMetrics> Metrics { get; set; } = new List<StockMetrics>();
        public StockRating StockRating { get; set; } = new StockRating();
        public Dcf Dcf { get; set; } = new Dcf();

    }
}
