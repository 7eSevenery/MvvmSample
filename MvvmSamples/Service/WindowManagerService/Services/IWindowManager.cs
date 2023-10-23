namespace WindowManagerService.Services
{
    internal interface IWindowManager
    {
        void Show<ViewModel>();
        void Hide<ViewModel>();
        void Close<ViewModel>();
    }
}
