using AppController.Core.Activation;
using System;
using System.Windows;

namespace AppController.Core.Controller
{
    public class ControllerConfigurator<TView, TViewModel> : ViewResolver<TView, TViewModel>, 
        IControllerConfigurator<TView, TViewModel>
        where TView : FrameworkElement where TViewModel : class
    {
        public ControllerConfigurator(IViewFactory viewFactory) : base(viewFactory)
        { }

        public IControllerConfigurator<TView, TViewModel> AdditionalViewModelParams(params object[] args)
        {
            if(args?.Length > 0)
            {
                _additionalViewModelArgs = args;
            }

            return this;
        }

        public IControllerConfigurator<TView, TViewModel> AdditionalViewParams(params object[] args)
        {
            if (args?.Length > 0)
            {
                _additionalViewArgs = args;
            }

            return this;
        }

        public IControllerConfigurator<TView, TViewModel> View(Action<TView> action)
        {
            if (action == null)
                throw new ArgumentNullException();

            if (!_viewActions.Contains(action))
                _viewActions.Add(action);

            return this;
        }
        public IControllerConfigurator<TView, TViewModel> ViewModel(Action<TViewModel> action)
        {
            if (action == null)
                throw new ArgumentNullException();

            if (!_viewModelActions.Contains(action))
                _viewModelActions.Add(action);

            return this;
        }
        
    }
}
