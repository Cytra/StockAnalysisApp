using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockAnalysisApp.Data.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stocks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Symbol = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stocks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Dcf",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(nullable: false),
                    Symbol = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    StockPrice = table.Column<double>(nullable: false),
                    DCF = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dcf", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dcf_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockMetrics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    date = table.Column<DateTime>(nullable: false),
                    RevenueperShare = table.Column<double>(nullable: false),
                    NetIncomeperShare = table.Column<double>(nullable: false),
                    OperatingCashFlowperShare = table.Column<double>(nullable: false),
                    FreeCashFlowperShare = table.Column<double>(nullable: false),
                    CashperShare = table.Column<double>(nullable: false),
                    BookValueperShare = table.Column<double>(nullable: false),
                    TangibleBookValueperShare = table.Column<double>(nullable: false),
                    ShareholdersEquityperShare = table.Column<double>(nullable: false),
                    InterestDebtperShare = table.Column<double>(nullable: false),
                    MarketCap = table.Column<double>(nullable: false),
                    EnterpriseValue = table.Column<double>(nullable: false),
                    PEratio = table.Column<double>(nullable: false),
                    PricetoSalesRatio = table.Column<double>(nullable: false),
                    POCFratio = table.Column<double>(nullable: false),
                    PFCFratio = table.Column<double>(nullable: false),
                    PBratio = table.Column<double>(nullable: false),
                    PTBratio = table.Column<double>(nullable: false),
                    EVtoSales = table.Column<double>(nullable: false),
                    EnterpriseValueoverEBITDA = table.Column<double>(nullable: false),
                    EVtoOperatingcashflow = table.Column<double>(nullable: false),
                    EVtoFreecashflow = table.Column<double>(nullable: false),
                    EarningsYield = table.Column<double>(nullable: false),
                    FreeCashFlowYield = table.Column<double>(nullable: false),
                    DebttoEquity = table.Column<double>(nullable: false),
                    DebttoAssets = table.Column<double>(nullable: false),
                    NetDebttoEBITDA = table.Column<double>(nullable: false),
                    Currentratio = table.Column<double>(nullable: false),
                    InterestCoverage = table.Column<double>(nullable: false),
                    IncomeQuality = table.Column<double>(nullable: false),
                    DividendYield = table.Column<double>(nullable: false),
                    PayoutRatio = table.Column<double>(nullable: false),
                    SGAtoRevenue = table.Column<double>(nullable: false),
                    RDtoRevenue = table.Column<double>(nullable: false),
                    IntangiblestoTotalAssets = table.Column<double>(nullable: false),
                    CapextoOperatingCashFlow = table.Column<double>(nullable: false),
                    CapextoRevenue = table.Column<double>(nullable: false),
                    CapextoDepreciation = table.Column<double>(nullable: false),
                    StockbasedcompensationtoRevenue = table.Column<double>(nullable: false),
                    GrahamNumber = table.Column<double>(nullable: false),
                    ROIC = table.Column<double>(nullable: false),
                    ReturnonTangibleAssets = table.Column<double>(nullable: false),
                    GrahamNetNet = table.Column<double>(nullable: false),
                    WorkingCapital = table.Column<double>(nullable: false),
                    TangibleAssetValue = table.Column<double>(nullable: false),
                    NetCurrentAssetValue = table.Column<double>(nullable: false),
                    InvestedCapital = table.Column<double>(nullable: false),
                    AverageReceivables = table.Column<double>(nullable: false),
                    AveragePayables = table.Column<double>(nullable: false),
                    AverageInventory = table.Column<double>(nullable: false),
                    DaysSalesOutstanding = table.Column<double>(nullable: false),
                    DaysPayablesOutstanding = table.Column<double>(nullable: false),
                    DaysofInventoryonHand = table.Column<double>(nullable: false),
                    ReceivablesTurnover = table.Column<double>(nullable: false),
                    PayablesTurnover = table.Column<double>(nullable: false),
                    InventoryTurnover = table.Column<double>(nullable: false),
                    ROE = table.Column<double>(nullable: false),
                    CapexperShare = table.Column<double>(nullable: false),
                    StockId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockMetrics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockMetrics_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StockRating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockId = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: false),
                    Rating = table.Column<string>(nullable: true),
                    Recommendation = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockRating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockRating_Stocks_StockId",
                        column: x => x.StockId,
                        principalTable: "Stocks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dcf_StockId",
                table: "Dcf",
                column: "StockId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_StockMetrics_StockId",
                table: "StockMetrics",
                column: "StockId");

            migrationBuilder.CreateIndex(
                name: "IX_StockRating_StockId",
                table: "StockRating",
                column: "StockId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dcf");

            migrationBuilder.DropTable(
                name: "StockMetrics");

            migrationBuilder.DropTable(
                name: "StockRating");

            migrationBuilder.DropTable(
                name: "Stocks");
        }
    }
}
