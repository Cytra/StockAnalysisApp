using AutoFixture;
using AutoFixture.AutoMoq;
using NUnit.Framework;
using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Logger.Loggers;
using StockAnalysisApp.Services.API;
using StockAnalysisApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.UIWPF
{
    public class DCFTests
    {
        IFixture _fixture;
        private List<Stock> testStockListOne;
        private List<Stock> testStockListThree;
        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture().Customize(new AutoMoqCustomization { ConfigureMembers = true });
        }

        //[Test]
        //public void GetStockListStringTestOneStock()
        //{
        //    testStockListOne = new List<Stock>();
        //    testStockListOne.Add(_fixture.Create<Stock>());
        //    var sut = new StockSymbolService();
        //    var stockList = sut.GetStockListString(testStockListOne);
        //    Assert.AreEqual(testStockListOne[0].Symbol, stockList);
        //}

        //[Test]
        //public void GetStockListStringTestSeveralStocks()
        //{
        //    testStockListThree = new List<Stock>();
        //    testStockListThree.Add(new Stock() { Symbol = "AAPL" });
        //    testStockListThree.Add(new Stock() { Symbol = "TWIS" });
        //    testStockListThree.Add(new Stock() { Symbol = "MSFT" });
        //    var sut = new StockSymbolService();
        //    var stockList = sut.GetStockListString(testStockListThree);
        //    Assert.AreEqual("AAPL,TWIS,MSFT", stockList);
        //}
    }
}
