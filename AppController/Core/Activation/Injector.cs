using AppController.Core.DIContainer;
using AppController.Core.Dynamic;
using AppController.Core.Modules;
using AppController.Infrastructure.Attributes;
using AppController.Infrastructure.Extensions;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;

namespace AppController.Core.Activation
{
    public class Injector : IInjector
    {
        protected readonly IContainerCore _container;

        public Injector(IContainerCore container)
        {
            _container = container;
        }
        public object Inject(Type instanceType, object[] additionalArgs = null)
        {
            var constructors = InstanceExplorer.GetOrderedConstructorList(instanceType);

            foreach(var constructor in constructors)
            {
                var parameters = InstanceExplorer.GetNonOptionalParameters(constructor);
                var parameterTypes = parameters.Select(p => p.ParameterType);
                var bindings = _container.Mudule.Bindings.SearchBindings(parameterTypes);

                object[] arguments = null;

                if(additionalArgs != null && parameterTypes.Count() == (bindings.Count() + additionalArgs.Length))
                {
                    arguments = GetParametersImplementations(bindings).Concat(additionalArgs).ToArray();
                    object instance = Create(instanceType, arguments);

                    return instance;
                }
                else if(parameterTypes.Count() == bindings?.Count())
                {
                    arguments = GetParametersImplementations(bindings).ToArray();
                    object instance = Create(instanceType, arguments);

                    return instance;
                }
            }

            return null;
        }
        public TInstance Inject<TInstance>(Type instanceType)
        {
            return (TInstance)Inject(instanceType);
        }
        public void InjectValues(object instance, IEnumerable<FieldInfo> injectedFields)
        {
            foreach(var field in injectedFields)
            {
                if (field.FieldType.IsEquivalentTo(typeof(IControllerCore)))
                {
                    IModule module = Activator.CreateInstance(field.GetCustomAttribute<InjectedAttribute>().ModuleType) as IModule;
                    field.SetValue(instance, new ControllerCore(module, _container));
                }
                else if (field.FieldType.IsEquivalentTo(typeof(IContainerCore)))
                {
                    IModule module = Activator.CreateInstance(field.GetCustomAttribute<InjectedAttribute>().ModuleType) as IModule;
                    field.SetValue(instance, new DIContainer.DIContainer(module));
                }
            }
        }
        private List<object> GetParametersImplementations(IEnumerable<IBinding> bindings)
        {
            List<object> parameters = new List<object>();

            foreach (var binding in bindings)
            {
                parameters.Add(_container.ResolveInterface(binding.BindingType));
            }

            return parameters;
        }
        private object Create(Type instanceType, object[] args)
        {
            object instance =  Activator.CreateInstance(instanceType, BindingFlags.CreateInstance |
                BindingFlags.Public | BindingFlags.Instance | BindingFlags.OptionalParamBinding, null, args,
                CultureInfo.CurrentCulture);

            if (InstanceExplorer.TryGetInjectedFields(instance, out List<FieldInfo> injectedFields))
            {
                InjectValues(instance, injectedFields);
            }

            return instance;
        }
    }
}
