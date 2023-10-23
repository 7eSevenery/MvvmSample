using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WindowReuse.ViewModels;
using WindowReuse.Views;

namespace WindowReuse
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public new static App Current => (App)Application.Current;

        public IServiceProvider ServiceProvider { get; }

        private static IServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<MainWindow>(sp => new MainWindow
            {
                DataContext = sp.GetService<MainWindowViewModel>()
            });

            services.AddTransient<ReuseWindowViewModel>();
            services.AddTransient<ReuseWindow>(sp => new ReuseWindow
            {
                DataContext = sp.GetService<ReuseWindowViewModel>()
            });

            return services.BuildServiceProvider();
        }

        public App()
        {
            ServiceProvider = ConfigureServices();
        }
        private void ApplicationStartup(object sender, StartupEventArgs e)
        {
            var window = ServiceProvider.GetService<MainWindow>();
            window!.Show();
        }
    }
}
