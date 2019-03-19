using AppController.Core.Activation;
using System.Windows;

namespace AppController.Core.Controller
{
    public interface IController
    {
        IControllerConfigurator<TView, TViewModel> GetConfigs<TView, TViewModel>() where TView : FrameworkElement where TViewModel : class;
        IView<TView, TViewModel> ResolveView<TView, TViewModel>() where TView : FrameworkElement where TViewModel : class;
        IViewFactory ViewFactory { get; }
    }
}
