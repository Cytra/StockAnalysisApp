using StockAnalysisApp.Logger.Loggers;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace StockAnalysisApp.UIWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IWindowsLogger _logger;
        public App()
        {
            InitializeComponent();
        }

        const string TechErrorMessage = "A technical error has occured. Please contact technical support.";
        protected override void OnStartup(StartupEventArgs e)
        {
            _logger = new ConsoleLogger();
            try
            {
                Current.DispatcherUnhandledException += GlobalExceptionHandler;
                AppDomain.CurrentDomain.UnhandledException += AppDomainExceptionhandler;
            }
            catch (Exception ex)
            {
                _logger.WriteError(ex.Message, ex);
                MessageBox.Show("Application Failed", "Windows party application", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                Environment.Exit(9);
            }
            base.OnStartup(e);
        }

        private void AppDomainExceptionhandler(object sender, UnhandledExceptionEventArgs e)
        {
            HandleUnhandledException(e.ExceptionObject as Exception);
        }

        private void GlobalExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;
            HandleUnhandledException(e.Exception);
        }

        private void HandleUnhandledException(Exception exception)
        {
            _logger.WriteError(exception.GetBaseException().Message, exception);
            MessageBox.Show(TechErrorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
