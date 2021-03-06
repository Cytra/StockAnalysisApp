﻿using AutoMapper;
using Caliburn.Micro;
using StockAnalysisApp.Core.DTOs;
using StockAnalysisApp.Core.Model;
using StockAnalysisApp.Data;
using StockAnalysisApp.Data.DbContexts;
using StockAnalysisApp.Data.Repositories;
using StockAnalysisApp.Logger.Loggers;
using StockAnalysisApp.Services.API;
using StockAnalysisApp.Services.ApiFacade;
using StockAnalysisApp.Services.Interfaces;
using StockAnalysisApp.UIWPF.ViewModels;
using StockAnalysisApp.UIWPF.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StockAnalysisApp.UIWPF
{
    public class Bootstrapper : BootstrapperBase
    {
        private SimpleContainer _container = new SimpleContainer();
        public Bootstrapper()
        {
            Initialize();
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<MainViewModel>();
        }

        protected override void Configure()
        {
            var _config = new MapperConfiguration(cfg => {
                cfg.CreateMap<StockListItem, Stock>()
                .ForMember(dest => dest.Name, org => org.MapFrom(source => source.name))
                .ForMember(dest => dest.Price, org => org.MapFrom(source => source.price))
                .ForMember(dest => dest.Symbol, org => org.MapFrom(source => source.symbol))
                .ForMember(desc => desc.Dcf, org => org.Ignore())
                .ForMember(desc => desc.Metrics, org => org.Ignore())
                .ForMember(desc => desc.StockRating, org => org.Ignore());

                cfg.CreateMap<CompanyKeyMetricsMetricsDto, StockMetrics>();

                cfg.CreateMap<CompanyKeyMetricsDto, Stock>()
                .ForMember(dest => dest.Metrics, org => org.MapFrom(source => source.metrics))
                .ForMember(desc => desc.Dcf, org => org.Ignore())
                .ForMember(desc => desc.StockRating, org => org.Ignore());

                cfg.CreateMap<RatingDto, StockRating>();

                cfg.CreateMap<CompanyRatingDto, Stock>()
                .ForMember(desc => desc.StockRating, org => org.MapFrom(source => source.Rating))
                .ForMember(desc => desc.Dcf, org => org.Ignore())
                .ForMember(desc => desc.Metrics, org => org.Ignore());

                cfg.CreateMap<DcfDto, Dcf>();
            });

            _container.Instance(_container);
            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IWindowsLogger, ConsoleLogger>()
                .PerRequest<IStockListService,StockListService>()
                .PerRequest<IDCFService,DCFService>()
                .PerRequest<ICompanyRatingService, CompanyRatingService>()
                .PerRequest<IStockSymbolService,StockSymbolService>()
                .PerRequest<ICompanyKeyMetricsService, CompanyKeyMetricsService>()
                //Facade
                .PerRequest<IDcfFacade, DcfFacade>()
                .PerRequest<ICompanyKeyMetricsFacade, CompanyKeyMetricsFacade>()
                .PerRequest<ICompanyRatingFacade, CompanyRatingFacade>()
                .PerRequest<IStockListFacade, StockListFacade>()
                .PerRequest<IStockRepoFacade, StockRepoFacade>()
                //Repo
                .PerRequest<IDcfRepository, DcfRepository>()
                .PerRequest<IStockRepository, StockRepository>()
                .PerRequest<StockDbContext>()   
                //ViewModels
                .PerRequest<CompanyKeyMetricsViewModel>()
                .PerRequest<DCFStrategyViewModel>()
                .PerRequest<MainViewModel>()
                .RegisterInstance(
                    typeof(IMapper),
                    "automapper",
                    _config.CreateMapper());
        }

        protected override object GetInstance(Type service, string key)
        {
            return _container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return _container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            _container.BuildUp(instance);
        }
    }
}
