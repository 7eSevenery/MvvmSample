using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WindowManagerService.Services;

namespace WindowManagerService.ViewModels
{
    internal partial class MainWindowViewModel : ObservableObject
    {
        private readonly IWindowManager _WindowManager;

        public MainWindowViewModel(IWindowManager WM)
        {
            _WindowManager = WM;
        }

        [RelayCommand]
        private void OpenMusicWindow()
        {
            _WindowManager.Show<MusicViewModel>();
        }

        [RelayCommand]
        private void OpenMovieWindow()
        {
            _WindowManager.Show<MovieViewModel>();
        }
    }
}
