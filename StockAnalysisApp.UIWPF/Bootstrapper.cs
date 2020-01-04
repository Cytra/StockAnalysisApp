using AutoMapper;
using Caliburn.Micro;
using StockAnalysisApp.Core.DTOs;
using StockAnalysisApp.Core.Model;
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
                .ForMember(dest => dest.Symbol, org => org.MapFrom(source => source.symbol));

                cfg.CreateMap<DcfDto, Stock>()
                .ForMember(dest => dest.DCF, org => org.MapFrom(source => source.DCF));
            });

            _container.Instance(_container);
            _container
                .Singleton<IWindowManager, WindowManager>()
                .Singleton<IEventAggregator, EventAggregator>()
                .Singleton<IWindowsLogger, ConsoleLogger>()
                .Singleton<IStockListService,StockListService>()
                .Singleton<IDCFService,DCFService>()
                .Singleton<IStockSymbolService,StockSymbolService>()
                .PerRequest<IDcfFacade, DcfFacade>()
                .PerRequest<IDcfRepository, DcfRepository>()
                .PerRequest<StockDbContext>()                
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
