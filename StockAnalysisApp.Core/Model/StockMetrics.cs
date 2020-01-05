using System;
using System.Collections.Generic;
using System.Text;

namespace StockAnalysisApp.Core.Model
{
    public class StockMetrics
    {
        public int Id { get; set; }
        public DateTime date { get; set; }
        public double RevenueperShare { get; set; }
        public double NetIncomeperShare { get; set; }
        public double OperatingCashFlowperShare { get; set; }
        public double FreeCashFlowperShare { get; set; }
        public double CashperShare { get; set; }
        public double BookValueperShare { get; set; }
        public double TangibleBookValueperShare { get; set; }
        public double ShareholdersEquityperShare { get; set; }
        public double InterestDebtperShare { get; set; }
        public double MarketCap { get; set; }
        public double EnterpriseValue { get; set; }
        public double PEratio { get; set; }
        public double PricetoSalesRatio { get; set; }
        public double POCFratio { get; set; }
        public double PFCFratio { get; set; }
        public double PBratio { get; set; }
        public double PTBratio { get; set; }
        public double EVtoSales { get; set; }
        public double EnterpriseValueoverEBITDA { get; set; }
        public double EVtoOperatingcashflow { get; set; }
        public double EVtoFreecashflow { get; set; }
        public double EarningsYield { get; set; }
        public double FreeCashFlowYield { get; set; }
        public double DebttoEquity { get; set; }
        public double DebttoAssets { get; set; }
        public double NetDebttoEBITDA { get; set; }
        public double Currentratio { get; set; }
        public double InterestCoverage { get; set; }
        public double IncomeQuality { get; set; }
        public double DividendYield { get; set; }
        public double PayoutRatio { get; set; }
        public double SGAtoRevenue { get; set; }
        public double RDtoRevenue { get; set; }
        public double IntangiblestoTotalAssets { get; set; }
        public double CapextoOperatingCashFlow { get; set; }
        public double CapextoRevenue { get; set; }
        public double CapextoDepreciation { get; set; }
        public double StockbasedcompensationtoRevenue { get; set; }
        public double GrahamNumber { get; set; }
        public double ROIC { get; set; }
        public double ReturnonTangibleAssets { get; set; }
        public double GrahamNetNet { get; set; }
        public double WorkingCapital { get; set; }
        public double TangibleAssetValue { get; set; }
        public double NetCurrentAssetValue { get; set; }
        public double InvestedCapital { get; set; }
        public double AverageReceivables { get; set; }
        public double AveragePayables { get; set; }
        public double AverageInventory { get; set; }
        public double DaysSalesOutstanding { get; set; }
        public double DaysPayablesOutstanding { get; set; }
        public double DaysofInventoryonHand { get; set; }
        public double ReceivablesTurnover { get; set; }
        public double PayablesTurnover { get; set; }
        public double InventoryTurnover { get; set; }
        public double ROE { get; set; }
        public double CapexperShare { get; set; }
    }
}
