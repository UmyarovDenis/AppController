using AppController.Core.Dynamic;
using AppController.Infrastructure.Exceptions;
using System;
using System.Windows;

namespace AppController.Infrastructure.Services
{
    internal static class Overlooker
    {
        public static void CheckExistenceBinding<TBinding>(IBindingRepository bindingRepository)
        {
            if (bindingRepository.GetBinding<TBinding>() == null)
                throw new BindingNotExistException($"{typeof(TBinding).Name} not founded in current module. Module: {bindingRepository.GetType().Name}");
        }
        public static void CheckViewModelBinding<TView, TViewModel>(IBindingRepository bindingRepository)
            where TView : FrameworkElement where TViewModel : class
        {
            Type serviceType = bindingRepository.GetBinding<TView>().ServiceType;

            if (!serviceType.IsEquivalentTo(typeof(TViewModel)))
                throw new ServiceNotExistException($"{typeof(TViewModel).Name} is not a binding to {typeof(TView).Name}. Binding service: {serviceType.Name}");
        }
    }
}
