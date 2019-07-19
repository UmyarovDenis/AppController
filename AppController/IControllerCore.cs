using AppController.Core.Activation;
using AppController.Core.Controller;
using AppController.Core.Controller.Navigation;
using AppController.Core.DIContainer;
using System.Windows;

namespace AppController
{
    public interface IControllerCore
    {
        IContainerCore Container { get; }
        IControllerConfigurator<TView, TViewModel> GetConfigs<TView, TViewModel>() where TView : FrameworkElement where TViewModel : class;
        IView<TView, TViewModel> ResolveView<TView, TViewModel>() where TView : FrameworkElement where TViewModel : class;
        IViewFactory ViewFactory { get; }
        IPageNavigator PageNavigator { get; set; }
    }
}
