using AppController.Core.DIContainer;
using AppController.Core.Dynamic;
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
        public object Inject(Type instanceType)
        {
            var constructors = InstanceExplorer.GetOrderedConstructorList(instanceType);

            foreach(var constructor in constructors)
            {
                var parameters = InstanceExplorer.GetNonOptionalParameters(constructor);
                var parameterTypes = parameters.Select(p => p.ParameterType);
                var bindings = _container.Mudule.Bindings.SearchBindings(parameterTypes);

                if(parameterTypes.Count() == bindings.Count())
                {
                    var @params = GetParametersImplementations(bindings).ToArray();
                    return Activator.CreateInstance(instanceType, BindingFlags.CreateInstance |
                                                                  BindingFlags.Public |
                                                                  BindingFlags.Instance |
                                                                  BindingFlags.OptionalParamBinding, null, @params,
                                                                  CultureInfo.CurrentCulture);
                }
            }

            return null;
        }
        public TInstance Inject<TInstance>(Type instanceType)
        {
            return (TInstance)Inject(instanceType);
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
    }
}
