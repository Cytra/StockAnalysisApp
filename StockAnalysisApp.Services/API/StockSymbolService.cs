using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockAnalysisApp.Services.API
{
    public class StockSymbolService : IStockSymbolService
    {
        List<string> invalidStocks = new List<string>()
            {
                "CSRA", "BUFF", "MITL", "TAHO",
                "STO", "QM", "CGI", "MTU", "VR",
                "LNCE", "DYN", "LOXO", "BWP", "CALD",
                "FAC", "NSU", "LFIN", "COTV", "HTM",
                "FOGO", "TNH", "AHP", "WG", "KYE",
                "BYBK", "IBRT", "CSBK", "PSDV", "MSFG",
                "AFAM", "CGNT", "CXRX", "INTX","MNGA",
                "VDTH", "AGA", "AHPAU", "ARGS", "BHAC",
                "BHACU", "BLNG", "BUR", "CHOC", "CMDT",
                "CNSF", "CRVP", "EACQ","ELECU", "ERN",
                "FNTEU", "GOP", "GRR", "ICI", "INDF",
                "INP", "JEM", "JRJR", "JXSB", "LEXEB",
                "LOGO", "MIIIU", "ONG", "ORPN", "PFK",
                "PTM", "RCOM", "SBV", "SFB", "STLRU",
                "TIL", "UBC", "UBM", "HMY","MFGP","TS",
                "NTR", "FRC", "TSM", "BBVA", "SAN",
                "FWONK", "DRE", "AMX", "TMHC"
            };

        public List<string> GetStockListString(List<Stock> stocks, int frequancy)
        {
            
            RemoveBannedStocks(stocks);
            var result = new List<string>();
            var currentStockList = string.Empty;
            foreach (var stock in stocks)
            {
                if (stocks.IndexOf(stock) % frequancy == 0)
                {
                    if (!string.IsNullOrWhiteSpace(currentStockList))
                    {
                        result.Add(currentStockList);
                        currentStockList = string.Empty;
                    }
                };

                if (!string.IsNullOrWhiteSpace(stock.Symbol))
                {
                    if (currentStockList.Length == 0)
                    {
                        currentStockList += stock.Symbol;
                    }
                    else
                    {
                        currentStockList += "," + stock.Symbol;
                    }
                }
            }
            return result;
        }

        private bool ValidTicker(string ticker)
        {
            if (invalidStocks.Contains(ticker))
            {
                return false;
            }
            return true;
        }

        private void RemoveBannedStocks(List<Stock> stocks)
        {
            foreach(var bannedStock in invalidStocks)
            {
                stocks.RemoveAll(x => x.Symbol == bannedStock);
            }
        }
    }
}
