using System;
using System.Windows;
using CustomerApp.ViewModel;
using CustomerLib;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerApp
{
    /// <summary>
    /// C:\Temp\Bill0420\WorkingDocs\Programming\MVVM\MvvmApp-main\MvvmApp-main\CustomerApp - Mvvm\CustomerApp\MainWindow.xaml.cs
    /// Interaction logic for App.xaml
    /// https://blogs.msmvps.com/bsonnino/2021/02/13/implementing-the-mvvm-pattern-in-a-wpf-app-with-the-mvvm-community-toolkit/#:~:text=%20Implementing%20the%20MVVM%20pattern%20in%20a%20WPF,To%20convert%20the%20app%2C%20we%E2%80%99ll%20start...%20More%20
    /// </summary>
    public partial class App
    {
        public App()
        {
            Services = ConfigureServices();
        }

        public new static App Current => (App) Application.Current;

        public IServiceProvider Services { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ICustomerRepository, CustomerRepository>();
            services.AddSingleton<MainViewModel>();

            return services.BuildServiceProvider();
        }

        public MainViewModel MainVM => Services.GetService<MainViewModel>();
    }
}