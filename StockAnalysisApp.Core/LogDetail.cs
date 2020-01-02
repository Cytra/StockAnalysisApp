using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core
{
    public class LogDetail
    {
        public LogDetail()
        {
            Timestamp = DateTime.Now;
            AdditionalInfo = new Dictionary<string, object>();
        }
        public DateTime Timestamp { get; set; }
        public string Message { get; set; }
        public string UserName { get; set; }
        public Exception Exception { get; set; }
        public Dictionary<string, object> AdditionalInfo { get; set; }
    }
}
