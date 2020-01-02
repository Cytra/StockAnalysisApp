using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Logger.Loggers
{
    public interface IWindowsLogger
    {
        void WriteError(string message, Exception ex);
        void WriteInformation(string message);
    }
}
