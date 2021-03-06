﻿using AutoMapper;
using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Data.Repositories;
using StockAnalysisApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StockAnalysisApp.Services.ApiFacade
{
    public class StockListFacade : IStockListFacade
    {
        private readonly IStockListService _stockListService;
        private readonly IMapper _mapper;
        private readonly IStockRepoFacade _stockRepoFacade;

        public StockListFacade(
            IStockListService stockListService,
            IMapper mapper,
            IStockRepoFacade stockRepoFacade)
        {
            _stockListService = stockListService ?? throw new ArgumentNullException(nameof(stockListService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _stockRepoFacade = stockRepoFacade ?? throw new ArgumentNullException(nameof(stockRepoFacade));
        }

        public async Task<List<Stock>> GetStockList()
        {
            var stockList = await _stockListService.GetStockList();
            var stocks = _mapper.Map<List<Stock>>(stockList.symbolsList);
            //await _stockRepoFacade.SaveStocks(stocks);
            return stocks;
        }
    }
}
