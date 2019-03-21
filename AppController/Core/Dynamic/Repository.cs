using System;
using System.Linq;
using System.Collections.Generic;

namespace AppController.Core.Dynamic
{
    public class Repository : IBindingRepository
    {
        private readonly IDictionary<Type, IBinding> _bindings;

        public Repository()
        {
            _bindings = new Dictionary<Type, IBinding>();
        }
        public void AddBinding(IBinding binding)
        {
            if (!_bindings.ContainsKey(binding.BindingType))
            {
                _bindings.Add(binding.BindingType, binding);
            }
        }
        public void RemoveBinding(IBinding binding)
        {
            if (_bindings.ContainsKey(binding.BindingType))
            {
                _bindings.Remove(binding.BindingType);
            }
        }
        public void RemoveBinding<TBinding>()
        {
            if (_bindings.ContainsKey(typeof(TBinding)))
            {
                _bindings.Remove(typeof(TBinding));
            }
        }
        public IBinding GetBinding<TBinding>()
        {
            if (_bindings.ContainsKey(typeof(TBinding)))
                return _bindings[typeof(TBinding)];

            return null;
        }
        public IBinding GetBinding(Type bindingType)
        {
            if (_bindings.ContainsKey(bindingType))
                return _bindings[bindingType];

            return null;
        }
        public IBinding GetBindingByImplementation<TImplementation>()
        {
            return TryGetBinding(typeof(TImplementation));
        }
        public IBinding GetBindingByImplementation(Type implementationType)
        {
            return TryGetBinding(implementationType);
        }
        private IBinding TryGetBinding(Type implementationType)
        {
            return _bindings.FirstOrDefault(b => implementationType.IsEquivalentTo(b.Value.ServiceType)).Value;
        }
    }
}
