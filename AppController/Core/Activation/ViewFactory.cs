using AppController.Core.Controller.Navigation;
using AppController.Core.Dynamic;
using AppController.Core.Modules;
using AppController.Infrastructure.Enums;
using AppController.Infrastructure.Services;
using System;
using System.Linq;
using System.Reflection;
using System.Collections.Generic;
using System.Windows;

namespace AppController.Core.Activation
{
    public class ViewFactory : IViewFactory
    {
        private readonly IBindingRepository _viewModelsBindings;
        private readonly IImplementor _implementor;

        public ViewFactory(IModule controllerModule, IImplementor implementor)
        {
            _viewModelsBindings = controllerModule.Bindings;
            _implementor = implementor;
        }

        public TView GetView<TView>() where TView : FrameworkElement
        {
            return CreateView<TView>(GetBinding<TView>());
        }
        public TView GetView<TView>(Action<TView> viewAction) where TView : FrameworkElement
        {
            TView view = CreateView<TView>(GetBinding<TView>());
            viewAction?.Invoke(view);

            return view;
        }
        public TView GetView<TView>(Action<TView> viewAction, params object[] viewArgs) where TView : FrameworkElement
        {
            IBinding binding = GetBinding<TView>();
            binding.BindingConstructorArguments = viewArgs;

            TView view = CreateView<TView>(binding);
            viewAction?.Invoke(view);

            return view;
        }
        public TView GetView<TView, TViewModel>(Action<TViewModel> viewModelAction)
            where TView : FrameworkElement
            where TViewModel : class
        {
            IBinding binding = GetBinding<TView>();

            Overlooker.CheckViewModelBinding<TView, TViewModel>(_viewModelsBindings);

            TView view = CreateView<TView>(binding);
            viewModelAction?.Invoke(view.DataContext as TViewModel);

            return view;
        }
        public TView GetView<TView, TViewModel>(Action<TViewModel> viewModelAction, params object[] viewModelArgs)
            where TView : FrameworkElement
            where TViewModel : class
        {
            IBinding binding = GetBinding<TView>();

            Overlooker.CheckViewModelBinding<TView, TViewModel>(_viewModelsBindings);

            binding.ServiceConstructorArguments = viewModelArgs;

            TView view = CreateView<TView>(binding);
            viewModelAction?.Invoke(view.DataContext as TViewModel);

            return view;
        }
        public Window GetWindow<TView>() where TView : FrameworkElement
        {
            if (!typeof(TView).BaseType.IsEquivalentTo(typeof(Window)))
                throw new ArgumentException($"{typeof(TView).Name} is not a Window");

            return CreateView<TView>(GetBinding<TView>()) as Window;
        }
        public Window GetWindow<TView, TViewModel>(IEnumerable<Action<TView>> viewActions, IEnumerable<Action<TViewModel>> viewModelActions,
            object[] additionalViewArgs, object[] additionalViewModelArgs) where TView : FrameworkElement where TViewModel : class
        {
            if (!typeof(TView).BaseType.IsEquivalentTo(typeof(Window)))
                throw new ArgumentException($"{typeof(TView).Name} is not a Window");

            IBinding binding = GetBinding<TView>();
            binding.BindingAdditionalArguments = additionalViewArgs;
            binding.ServiceAdditionalArguments = additionalViewModelArgs;

            Overlooker.CheckViewModelBinding<TView, TViewModel>(_viewModelsBindings);

            TView view = CreateView<TView>(binding);

            foreach (var action in viewActions)
                action?.Invoke(view);

            foreach (var action in viewModelActions)
                action?.Invoke(view.DataContext as TViewModel);

            return view as Window;
        }
        private IBinding GetBinding<TKey>()
        {
            Overlooker.CheckExistenceBinding<TKey>(_viewModelsBindings);
            return _viewModelsBindings.GetBinding<TKey>();
        }
        private IBinding GetBinding(Type keyType)
        {
            return _viewModelsBindings.GetBinding(keyType);
        }
        [Obsolete("Testing")]
        private Tuple<TView, object> GetContext<TView>(IBinding binding)
        {
            object viewModel = null;

            TView view = _implementor.CreateInstance<TView>(binding.BindingType, binding.BindingConstructorArguments,
                binding.BindingAdditionalArguments);

            if (binding.InstanceScopeType == InstanceScopeType.Singleton && binding.Instance != null)
            {
                viewModel = binding.Instance;
            }
            else
            {
                viewModel = _implementor.CreateInstance(binding.ServiceType, binding.ServiceConstructorArguments,
                    binding.ServiceAdditionalArguments);

                Type viewModelType = viewModel.GetType();

                if(Attribute.IsDefined(viewModelType, typeof(ControllerPageAttribute)))
                {
                    var pageBindings = viewModelType.GetCustomAttributes<ControllerPageAttribute>()
                        .Select(x => GetBinding(x.PageType));
                }
                
                if(binding.InstanceScopeType == InstanceScopeType.Singleton)
                    binding.Instance = viewModel;
            }

            return new Tuple<TView, object>(view, viewModel);
        }
        private Tuple<object, object>GetContext(IBinding binding)
        {
            object viewModel = null;

            var view = _implementor.CreateInstance(binding.BindingType, binding.BindingConstructorArguments,
                binding.BindingAdditionalArguments);

            if (binding.InstanceScopeType == InstanceScopeType.Singleton && binding.Instance != null)
            {
                viewModel = binding.Instance;
            }
            else
            {
                viewModel = _implementor.CreateInstance(binding.ServiceType, binding.ServiceConstructorArguments,
                    binding.ServiceAdditionalArguments);

                Type viewModelType = viewModel.GetType();

                if (Attribute.IsDefined(viewModelType, typeof(ControllerPageAttribute)))
                {
                    IEnumerable<FrameworkElement> pages = viewModelType.GetCustomAttributes<ControllerPageAttribute>()
                        .Select(x => CreateView(GetBinding(x.PageType)))
                        .Cast<FrameworkElement>();

                    FieldInfo controllerInfo = viewModelType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                        .FirstOrDefault(f => f.FieldType.IsEquivalentTo(typeof(IControllerCore)));

                    if (controllerInfo != null)
                    {
                        controllerInfo.FieldType.GetProperty("PageNavigator", BindingFlags.Public | BindingFlags.Instance)
                            .SetValue(controllerInfo.GetValue(viewModel), new PageNavigator(pages));
                    }
                }

                if (binding.InstanceScopeType == InstanceScopeType.Singleton)
                    binding.Instance = viewModel;
            }

            return new Tuple<object, object>(view, viewModel);
        }
        private TView CreateView<TView>(IBinding binding) where TView : FrameworkElement
        {
            return CreateView(binding) as TView;
        }
        private object CreateView(IBinding binding)
        {
            var tuple = GetContext(binding);

            FrameworkElement view = (FrameworkElement)tuple.Item1;
            view.DataContext = tuple.Item2;

            return view;
        }
    }
}
