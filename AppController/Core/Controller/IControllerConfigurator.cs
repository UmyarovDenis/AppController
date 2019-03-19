using System;
using System.Windows;

namespace AppController.Core.Controller
{
    public interface IControllerConfigurator<TView, TViewModel> : IView<TView, TViewModel> 
        where TView : FrameworkElement where TViewModel : class
    {
        IControllerConfigurator<TView, TViewModel> View(Action<TView> action);
        IControllerConfigurator<TView, TViewModel> ViewModel(Action<TViewModel> action);
    }
}
