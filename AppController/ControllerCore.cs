using System.Windows;
using AppController.Core.Activation;
using AppController.Core.Controller;
using AppController.Core.Controller.Navigation;
using AppController.Core.DIContainer;
using AppController.Core.Modules;
using AppController.Infrastructure.Services;

namespace AppController
{
    public class ControllerCore : IControllerCore
    {
        private readonly IModule _controllerModule;
        private readonly IContainerCore _container;
        private readonly IViewFactory _viewFactory;
        private IPageNavigator _pageNavigator;

        public ControllerCore(IModule controllerModule, IContainerCore container)
        {
            _controllerModule = controllerModule;
            _controllerModule.Load();
            _container = container;

            _viewFactory = new ViewFactory(_controllerModule, new Implementor(_container));
            //_container.Bind<IControllerCore>().ToInstance(this);
            _container.Bind<IControllerCore>().To<ControllerCore>()
                .WithArguments(_controllerModule, _container);
        }
        public IContainerCore Container
        {
            get { return _container; }
        }
        public IViewFactory ViewFactory
        {
            get { return _viewFactory; }
        }
        public IPageNavigator PageNavigator
        {
            get { return _pageNavigator; }
            set { _pageNavigator = value; }
        }

        public IControllerConfigurator<TView, TViewModel> GetConfigs<TView, TViewModel>() 
            where TView : FrameworkElement where TViewModel : class
        {
            Overlooker.CheckExistenceBinding<TView>(_controllerModule.Bindings);
            Overlooker.CheckViewModelBinding<TView, TViewModel>(_controllerModule.Bindings);

            return new ControllerConfigurator<TView, TViewModel>(_viewFactory);
        }
        public IView<TView, TViewModel> ResolveView<TView, TViewModel>() where TView : FrameworkElement where TViewModel : class
        {
            Overlooker.CheckExistenceBinding<TView>(_controllerModule.Bindings);
            Overlooker.CheckViewModelBinding<TView, TViewModel>(_controllerModule.Bindings);

            return new ViewResolver<TView, TViewModel>(_viewFactory);
        }
    }
}
