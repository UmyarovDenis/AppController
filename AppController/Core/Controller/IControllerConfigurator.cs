using System;
using System.Windows;

namespace AppController.Core.Controller
{
    public interface IControllerConfigurator<TView, TViewModel> : IView<TView, TViewModel> 
        where TView : FrameworkElement where TViewModel : class
    {
        IControllerConfigurator<TView, TViewModel> View(Action<TView> action);
        IControllerConfigurator<TView, TViewModel> ViewModel(Action<TViewModel> action);
        IControllerConfigurator<TView, TViewModel> AdditionalViewParams(params object[] args);
        IControllerConfigurator<TView, TViewModel> AdditionalViewModelParams(params object[] args);
    }
}
