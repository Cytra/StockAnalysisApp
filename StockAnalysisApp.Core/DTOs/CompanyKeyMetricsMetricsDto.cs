using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core.DTOs
{
    public class CompanyKeyMetricsMetricsDto
    {
        public DateTime date { get; set; }

        [JsonProperty(PropertyName = "Revenue per Share")]
        public double RevenueperShare { get; set; }

        [JsonProperty(PropertyName = "Net Income per Share")]
        public double NetIncomeperShare { get; set; }

        [JsonProperty(PropertyName = "Operating Cash Flow per Share")]
        public double OperatingCashFlowperShare { get; set; }

        [JsonProperty(PropertyName = "Free Cash Flow per Share")]
        public double FreeCashFlowperShare { get; set; }

        [JsonProperty(PropertyName = "Cash per Share")]
        public double CashperShare { get; set; }

        [JsonProperty(PropertyName = "Book Value per Share")]
        public double BookValueperShare { get; set; }

        [JsonProperty(PropertyName = "Tangible Book Value per Share")]
        public double TangibleBookValueperShare { get; set; }

        [JsonProperty(PropertyName = "Shareholders Equity per Share")]
        public double ShareholdersEquityperShare { get; set; }

        [JsonProperty(PropertyName = "Interest Debt per Share")]
        public double InterestDebtperShare { get; set; }

        [JsonProperty(PropertyName = "Market Cap")]
        public double MarketCap { get; set; }

        [JsonProperty(PropertyName = "Enterprise Value")]
        public double EnterpriseValue { get; set; }

        [JsonProperty(PropertyName = "PE ratio")]
        public double PEratio { get; set; }

        [JsonProperty(PropertyName = "Price to Sales Ratio")]
        public double PricetoSalesRatio { get; set; }

        [JsonProperty(PropertyName = "POCF ratio")]
        public double POCFratio { get; set; }

        [JsonProperty(PropertyName = "PFCF ratio")]
        public double PFCFratio { get; set; }

        [JsonProperty(PropertyName = "PB ratio")]
        public double PBratio { get; set; }

        [JsonProperty(PropertyName = "PTB ratio")]
        public double PTBratio { get; set; }

        [JsonProperty(PropertyName = "EV to Sales")]
        public double EVtoSales { get; set; }

        [JsonProperty(PropertyName = "Enterprise Value over EBITDA")]
        public double EnterpriseValueoverEBITDA { get; set; }

        [JsonProperty(PropertyName = "EV to Operating cash flow")]
        public double EVtoOperatingcashflow { get; set; }

        [JsonProperty(PropertyName = "EV to Free cash flow")]
        public double EVtoFreecashflow { get; set; }

        [JsonProperty(PropertyName = "Earnings Yield")]
        public double EarningsYield { get; set; }

        [JsonProperty(PropertyName = "Free Cash Flow Yield")]
        public double FreeCashFlowYield { get; set; }

        [JsonProperty(PropertyName = "Debt to Equity")]
        public double DebttoEquity { get; set; }

        [JsonProperty(PropertyName = "Debt to Assets")]
        public double DebttoAssets { get; set; }

        [JsonProperty(PropertyName = "Net Debt to EBITDA")]
        public double NetDebttoEBITDA { get; set; }

        [JsonProperty(PropertyName = "Current ratio")]
        public double Currentratio { get; set; }

        [JsonProperty(PropertyName = "Interest Coverage")]
        public double InterestCoverage { get; set; }

        [JsonProperty(PropertyName = "Income Quality")]
        public double IncomeQuality { get; set; }

        [JsonProperty(PropertyName = "Dividend Yield")]
        public double DividendYield { get; set; }

        [JsonProperty(PropertyName = "Payout Ratio")]
        public double PayoutRatio { get; set; }

        [JsonProperty(PropertyName = "SG&A to Revenue")]
        public double SGAtoRevenue { get; set; }

        [JsonProperty(PropertyName = "R&D to Revenue")]
        public double RDtoRevenue { get; set; }

        [JsonProperty(PropertyName = "Intangibles to Total Assets")]
        public double IntangiblestoTotalAssets { get; set; }

        [JsonProperty(PropertyName = "Capex to Operating Cash Flow")]
        public double CapextoOperatingCashFlow { get; set; }

        [JsonProperty(PropertyName = "Capex to Revenue")]
        public double CapextoRevenue { get; set; }

        [JsonProperty(PropertyName = "Capex to Depreciation")]
        public double CapextoDepreciation { get; set; }

        [JsonProperty(PropertyName = "Stock-based compensation to Revenue")]
        public double StockbasedcompensationtoRevenue { get; set; }

        [JsonProperty(PropertyName = "Graham Number")]
        public double GrahamNumber { get; set; }

        [JsonProperty(PropertyName = "ROIC")]
        public double ROIC { get; set; }

        [JsonProperty(PropertyName = "Return on Tangible Assets")]
        public double ReturnonTangibleAssets { get; set; }

        [JsonProperty(PropertyName = "Graham Net-Net")]
        public double GrahamNetNet { get; set; }

        [JsonProperty(PropertyName = "Working Capital")]
        public double WorkingCapital { get; set; }

        [JsonProperty(PropertyName = "Tangible Asset Value")]
        public double TangibleAssetValue { get; set; }

        [JsonProperty(PropertyName = "Net Current Asset Value")]
        public double NetCurrentAssetValue { get; set; }

        [JsonProperty(PropertyName = "Invested Capital")]
        public double InvestedCapital { get; set; }

        [JsonProperty(PropertyName = "Average Receivables")]
        public double AverageReceivables { get; set; }

        [JsonProperty(PropertyName = "Average Payables")]
        public double AveragePayables { get; set; }

        [JsonProperty(PropertyName = "Average Inventory")]
        public double AverageInventory { get; set; }

        [JsonProperty(PropertyName = "Days Sales Outstanding")]
        public double DaysSalesOutstanding { get; set; }

        [JsonProperty(PropertyName = "Days Payables Outstanding")]
        public double DaysPayablesOutstanding { get; set; }

        [JsonProperty(PropertyName = "Days of Inventory on Hand")]
        public double DaysofInventoryonHand { get; set; }

        [JsonProperty(PropertyName = "Receivables Turnover")]
        public double ReceivablesTurnover { get; set; }

        [JsonProperty(PropertyName = "Payables Turnover")]
        public double PayablesTurnover { get; set; }

        [JsonProperty(PropertyName = "Inventory Turnover")]
        public double InventoryTurnover { get; set; }

        [JsonProperty(PropertyName = "ROE")]
        public double ROE { get; set; }

        [JsonProperty(PropertyName = "Capex per Share")]
        public double CapexperShare { get; set; }
    }
}
