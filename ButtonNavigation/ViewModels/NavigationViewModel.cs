using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButtonNavigation.ViewModels
{
    public partial class NavigationViewModel : ObservableObject
    {
        private object _SelectedControl;
        public object SelectedControl
        {
            get => _SelectedControl;
            set
            {
                SetProperty(ref _SelectedControl, value);
            }
        }

        public NavigationViewModel()
        {
            SelectedControl = new MusicViewModel();
        }

        [RelayCommand]
        private void MusicNav()
        {
            SelectedControl = new MusicViewModel();
        }

        [RelayCommand]
        private void MovieNav()
        {
            SelectedControl = new MovieViewModel();
        }

        [RelayCommand]
        private void GameNav()
        {
            SelectedControl = new GameViewModel();
        }
    }

}
