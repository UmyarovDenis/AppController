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
                return CreateInstance(binding);
            }
            else if (instanceType.IsClass)
            {
                return Activate(instanceType);
            }

            throw new ArgumentException();
        }
        public object CreateInstance(Type instanceType, params object[] args)
        {
            if (args?.Length > 0)
            {
                return Activator.CreateInstance(instanceType, args);
            }

            return CreateInstance(instanceType);
        }
        public TInstance CreateInstance<TInstance>(Type instanceType, params object[] args)
        {
            return (TInstance)CreateInstance(instanceType, args);
        }
        public TInstance CreateInstance<TInstance>(IBinding binding)
        {
            return (TInstance)CreateInstance(binding);
        }
        public object CreateInstance(IBinding binding)
        {
            object instance = null;

            if (binding.InstanceScopeType == InstanceScopeType.Singleton && binding.Instance != null)
            {
                return binding.Instance;
            }

            if (binding?.ServiceConstructorArguments != null)
                return Activator.CreateInstance(binding.ServiceType, binding.ServiceConstructorArguments);

            instance = Activate(binding.ServiceType);

            if (binding.InstanceScopeType == InstanceScopeType.Singleton)
                binding.Instance = instance;

            return instance;
        }
        public object CreateInstance(Type instanceType, object[] args, object[] additionalArgs)
        {
            if (args?.Length > 0 && additionalArgs?.Length > 0)
            {
                object[] arguments = new object[args.Length + additionalArgs.Length];
                args.CopyTo(arguments, 0);
                additionalArgs.CopyTo(arguments, args.Length);

                return Activator.CreateInstance(instanceType, arguments);
            }

            return Inject(instanceType, additionalArgs);
        }
        public TInstance CreateInstance<TInstance>(Type instanceType, object[] args, object[] additionalArgs)
        {
            return (TInstance)CreateInstance(instanceType, args, additionalArgs);
        }
        public object Activate(Type instanceType)
        {
            if (InstanceExplorer.HasDefaultConstructor(instanceType))
            {
                return Activator.CreateInstance(instanceType);
            }
            else
            {
                return Inject(instanceType);
            }
        }
    }
}
