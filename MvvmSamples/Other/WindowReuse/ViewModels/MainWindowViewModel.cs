using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using WindowReuse.Views;

namespace WindowReuse.ViewModels
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        [RelayCommand]
        private void OpenMusic()
        {
            var window = App.Current.ServiceProvider.GetService<ReuseWindow>();
            window!.Show();
            WeakReferenceMessenger.Default.Send<MusicViewModel>(new MusicViewModel());
        }

        [RelayCommand]
        private void OpenMovie()
        {
            var window = App.Current.ServiceProvider.GetService<ReuseWindow>();
            window!.Show();
            WeakReferenceMessenger.Default.Send<MovieViewModel>(new MovieViewModel());
        }

        [RelayCommand]
        private void OpenGame()
        {
            var window = App.Current.ServiceProvider.GetService<ReuseWindow>();
            window!.Show();
            WeakReferenceMessenger.Default.Send<GameViewModel>(new GameViewModel());
        }
    }
}
