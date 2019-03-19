using AppController.Core.Dynamic;
using System.Windows;

namespace AppController.Core.Controller
{
    public interface IViewRegister
    {
        IComponent BindView<TView>() where TView : FrameworkElement;
    }
}
