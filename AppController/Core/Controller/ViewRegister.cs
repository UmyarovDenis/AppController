using AppController.Core.Dynamic;
using System.Windows;

namespace AppController.Core.Controller
{
    public class ViewRegister : IViewRegister
    {
        private readonly IBindableBase _bindableBase;

        public ViewRegister(IBindingRepository bindingRepository)
        {
            _bindableBase = new BindableBase(bindingRepository);
        }

        public IComponent BindView<TView>() where TView : FrameworkElement
        {
            return _bindableBase.Bind<TView>();
        }
    }
}
