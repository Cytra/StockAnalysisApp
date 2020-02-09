﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StockAnalysisApp.Data.DbContexts;

namespace StockAnalysisApp.Data.Migrations
{
    [DbContext(typeof(StockDbContext))]
    partial class StockDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("StockAnalysisApp.Core.DTOs.DcfDto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DCF")
                        .HasColumnType("float");

                    b.Property<double>("StockPrice")
                        .HasColumnType("float");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.Property<string>("symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Dcfs");
                });

            modelBuilder.Entity("StockAnalysisApp.Core.Model.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("DCF")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Symbol")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("StockAnalysisApp.Core.Model.StockMetrics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AverageInventory")
                        .HasColumnType("float");

                    b.Property<double>("AveragePayables")
                        .HasColumnType("float");

                    b.Property<double>("AverageReceivables")
                        .HasColumnType("float");

                    b.Property<double>("BookValueperShare")
                        .HasColumnType("float");

                    b.Property<double>("CapexperShare")
                        .HasColumnType("float");

                    b.Property<double>("CapextoDepreciation")
                        .HasColumnType("float");

                    b.Property<double>("CapextoOperatingCashFlow")
                        .HasColumnType("float");

                    b.Property<double>("CapextoRevenue")
                        .HasColumnType("float");

                    b.Property<double>("CashperShare")
                        .HasColumnType("float");

                    b.Property<double>("Currentratio")
                        .HasColumnType("float");

                    b.Property<double>("DaysPayablesOutstanding")
                        .HasColumnType("float");

                    b.Property<double>("DaysSalesOutstanding")
                        .HasColumnType("float");

                    b.Property<double>("DaysofInventoryonHand")
                        .HasColumnType("float");

                    b.Property<double>("DebttoAssets")
                        .HasColumnType("float");

                    b.Property<double>("DebttoEquity")
                        .HasColumnType("float");

                    b.Property<double>("DividendYield")
                        .HasColumnType("float");

                    b.Property<double>("EVtoFreecashflow")
                        .HasColumnType("float");

                    b.Property<double>("EVtoOperatingcashflow")
                        .HasColumnType("float");

                    b.Property<double>("EVtoSales")
                        .HasColumnType("float");

                    b.Property<double>("EarningsYield")
                        .HasColumnType("float");

                    b.Property<double>("EnterpriseValue")
                        .HasColumnType("float");

                    b.Property<double>("EnterpriseValueoverEBITDA")
                        .HasColumnType("float");

                    b.Property<double>("FreeCashFlowYield")
                        .HasColumnType("float");

                    b.Property<double>("FreeCashFlowperShare")
                        .HasColumnType("float");

                    b.Property<double>("GrahamNetNet")
                        .HasColumnType("float");

                    b.Property<double>("GrahamNumber")
                        .HasColumnType("float");

                    b.Property<double>("IncomeQuality")
                        .HasColumnType("float");

                    b.Property<double>("IntangiblestoTotalAssets")
                        .HasColumnType("float");

                    b.Property<double>("InterestCoverage")
                        .HasColumnType("float");

                    b.Property<double>("InterestDebtperShare")
                        .HasColumnType("float");

                    b.Property<double>("InventoryTurnover")
                        .HasColumnType("float");

                    b.Property<double>("InvestedCapital")
                        .HasColumnType("float");

                    b.Property<double>("MarketCap")
                        .HasColumnType("float");

                    b.Property<double>("NetCurrentAssetValue")
                        .HasColumnType("float");

                    b.Property<double>("NetDebttoEBITDA")
                        .HasColumnType("float");

                    b.Property<double>("NetIncomeperShare")
                        .HasColumnType("float");

                    b.Property<double>("OperatingCashFlowperShare")
                        .HasColumnType("float");

                    b.Property<double>("PBratio")
                        .HasColumnType("float");

                    b.Property<double>("PEratio")
                        .HasColumnType("float");

                    b.Property<double>("PFCFratio")
                        .HasColumnType("float");

                    b.Property<double>("POCFratio")
                        .HasColumnType("float");

                    b.Property<double>("PTBratio")
                        .HasColumnType("float");

                    b.Property<double>("PayablesTurnover")
                        .HasColumnType("float");

                    b.Property<double>("PayoutRatio")
                        .HasColumnType("float");

                    b.Property<double>("PricetoSalesRatio")
                        .HasColumnType("float");

                    b.Property<double>("RDtoRevenue")
                        .HasColumnType("float");

                    b.Property<double>("ROE")
                        .HasColumnType("float");

                    b.Property<double>("ROIC")
                        .HasColumnType("float");

                    b.Property<double>("ReceivablesTurnover")
                        .HasColumnType("float");

                    b.Property<double>("ReturnonTangibleAssets")
                        .HasColumnType("float");

                    b.Property<double>("RevenueperShare")
                        .HasColumnType("float");

                    b.Property<double>("SGAtoRevenue")
                        .HasColumnType("float");

                    b.Property<double>("ShareholdersEquityperShare")
                        .HasColumnType("float");

                    b.Property<int?>("StockId")
                        .HasColumnType("int");

                    b.Property<double>("StockbasedcompensationtoRevenue")
                        .HasColumnType("float");

                    b.Property<double>("TangibleAssetValue")
                        .HasColumnType("float");

                    b.Property<double>("TangibleBookValueperShare")
                        .HasColumnType("float");

                    b.Property<double>("WorkingCapital")
                        .HasColumnType("float");

                    b.Property<DateTime>("date")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("StockId");

                    b.ToTable("StockMetrics");
                });

            modelBuilder.Entity("StockAnalysisApp.Core.Model.StockMetrics", b =>
                {
                    b.HasOne("StockAnalysisApp.Core.Model.Stock", null)
                        .WithMany("Metrics")
                        .HasForeignKey("StockId");
                });
#pragma warning restore 612, 618
        }
    }
}
