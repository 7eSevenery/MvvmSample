using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComboBoxNavigation.ViewModels
{
    public class NavigationViewModel : ObservableObject
    {
        private List<string> _ComboBoxOptions;
        public List<string> ComboBoxOptions
        {
            get => _ComboBoxOptions;
            set
            {
                SetProperty(ref _ComboBoxOptions, value);
            }
        }

        private string _SelectedOption;
        public string SelectedOption
        {
            get => _SelectedOption;
            set
            {
                SetProperty(ref _SelectedOption, value);
                switch (_SelectedOption)
                {
                    case "Music":
                        SelectedControl = new MusicViewModel();
                        break;
                    case "Movie":
                        SelectedControl = new MovieViewModel();
                        break;
                    case "Game":
                        SelectedControl = new GameViewModel();
                        break;
                }
            }
        }

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
            ComboBoxOptions = new List<string>()
            {
                "Music",
                "Movie",
                "Game",
            };
            SelectedOption = "Movie";
        }
    }
}
