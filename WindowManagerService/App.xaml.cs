using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;
using WindowManagerService.Services;
using WindowManagerService.ViewModels;
using WindowManagerService.Views;

namespace WindowManagerService
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

            services.AddSingleton<IWindowManager, WindowManager>();

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<MainWindow>(sp => new MainWindow
            {
                DataContext = sp.GetService<MainWindowViewModel>()
            });

            services.AddTransient<MainWindowViewModel>();
            services.AddTransient<MainWindow>(sp => new MainWindow
            {
                DataContext = sp.GetService<MainWindowViewModel>()
            });

            services.AddTransient<MovieViewModel>();
            services.AddTransient<MovieView>(sp => new MovieView
            {
                DataContext = sp.GetService<MovieViewModel>()
            });

            services.AddTransient<MusicViewModel>();
            services.AddTransient<MusicView>(sp => new MusicView
            {
                DataContext = sp.GetService<MusicViewModel>()
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
