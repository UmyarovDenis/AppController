using System;

namespace AppController.Core.Dynamic
{
    public interface IBindingRepository
    {
        void AddBinding(IBinding binding);
        void RemoveBinding(IBinding binding);
        void RemoveBinding<TBinding>();
        IBinding GetBinding<TBinding>();
        IBinding GetBinding(Type bindingType);
        IBinding GetBindingByImplementation<TImplementation>();
        IBinding GetBindingByImplementation(Type implementationType);
    }
}
