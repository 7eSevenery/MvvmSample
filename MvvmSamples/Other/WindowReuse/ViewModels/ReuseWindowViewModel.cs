using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;

namespace WindowReuse.ViewModels
{
    internal partial class ReuseWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private object _Reuse;

        public ReuseWindowViewModel()
        {
            WeakReferenceMessenger.Default.Register<MusicViewModel>(this, OperatorHandle);
            WeakReferenceMessenger.Default.Register<MovieViewModel>(this, OperatorHandle);
            WeakReferenceMessenger.Default.Register<GameViewModel>(this, OperatorHandle);
        }

        private void OperatorHandle(object recipient, object obj)
        {
            Reuse = obj;
        }
    }
}
