using System;
using AppController.Core.DIContainer;
using AppController.Core.Dynamic;
using AppController.Infrastructure.Enums;

namespace AppController.Core.Activation
{
    public class Implementor : Injector, IImplementor
    {
        public Implementor(IContainerCore containerCore)
            : base(containerCore)
        { }

        public TInstance CreateInstance<TInstance>()
        {
            return (TInstance)CreateInstance(typeof(TInstance));
        }
        public object CreateInstance(Type instanceType)
        {
            IBinding binding = _container.Mudule.Bindings.GetBinding(instanceType);

            if (binding != null)
            {
                if (binding.InstanceScopeType == InstanceScopeType.Singleton && binding.Instance != null)
                {
                    return binding.Instance;
                }

                if (binding?.ServiceConstructorArguments != null)
                    return Activator.CreateInstance(instanceType, binding.ServiceConstructorArguments);

                object instance = null;

                if(InstanceExplorer.HasDefaultConstructor(binding.ServiceType))
                {
                    instance = Activator.CreateInstance(binding.ServiceType);
                }
                else
                {
                    instance = Inject(binding.ServiceType);
                }
                
                if (binding.InstanceScopeType == InstanceScopeType.Singleton)
                    binding.Instance = instance;

                return instance;
            }

            throw new ArgumentException();
        }
        public TInstance CreateInstance<TInstance>(IBinding binding)
        {
            throw new NotImplementedException();
        }
        public object CreateInstance(Type instanceType, params object[] args)
        {
            object instance = null;

            if (args?.Length > 0)
            {
                instance = Activator.CreateInstance(instanceType, args);
            }
            if (HasDefaultConstructor(instanceType))
            {
                instance = Activator.CreateInstance(instanceType);
            }

            return Inject(instanceType);
        }
        public TInstance CreateInstance<TInstance>(Type instanceType, params object[] args)
        {
            return (TInstance)CreateInstance(instanceType, args);
        }
        private bool HasDefaultConstructor(Type instanceType)
        {
            var constructors = instanceType.GetConstructors();

            if (constructors.Length > 1)
                return false;

            return true;
        }
    }
}
