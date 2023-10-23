using System;
using System.Collections.Generic;
using System.Windows;
using WindowManagerService.ViewModels;
using WindowManagerService.Views;

namespace WindowManagerService.Services
{
    internal class WindowManager : IWindowManager
    {
        private readonly Dictionary<Type, Type> _WindowManager;
        private readonly Dictionary<Type, Window> _OpeningWindow;

        public WindowManager()
        {
            _WindowManager = new Dictionary<Type, Type>()
            {
                { typeof(MusicViewModel), typeof(MusicView) },
                { typeof(MovieViewModel), typeof(MovieView) },
            };
            _OpeningWindow = new Dictionary<Type, Window>();
        }

        public void Show<ViewModel>()
        {
            Type wt = typeof(ViewModel);
            if (_WindowManager.TryGetValue(wt, out var WindowType))
            {
                if (_OpeningWindow.ContainsKey(wt))
                {
                    _OpeningWindow[wt].Activate();
                }
                else
                {
                    var view = App.Current.ServiceProvider.GetService(WindowType);
                    if (view is Window window)
                    {
                        window.Closed += (sender, e) =>
                        {
                            _OpeningWindow.Remove(wt);
                        };

                        _OpeningWindow.Add(wt, window);
                        window.Show();
                    }
                }
            }
        }

        public void Hide<ViewModel>()
        {
            Type wt = typeof(ViewModel);
            if (_OpeningWindow.ContainsKey(wt))
            {
                _OpeningWindow[wt].Hide();
            }
        }

        public void Close<ViewModel>()
        {
            Type wt = typeof(ViewModel);
            if (_OpeningWindow.ContainsKey(wt))
            {
                _OpeningWindow[wt].Close();
                _OpeningWindow.Remove(wt);
            }
        }
    }
}
