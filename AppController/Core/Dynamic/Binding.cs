using AppController.Infrastructure.Enums;
using System;

namespace AppController.Core.Dynamic
{
    public class Binding : IBinding
    {
        private Type _bindingType;
        private Type _serviceType;

        public Binding(Type bindingType, Type serviceType)
        {
            _bindingType = bindingType;
            _serviceType = serviceType;
            InstanceScopeType = InstanceScopeType.PerCall;
        }
        public Binding(Type bindingType, object instance) : this(bindingType, instance.GetType())
        {
            Instance = instance;
        }
        public Type BindingType
        {
            get { return _bindingType; }
        }
        public Type ServiceType
        {
            get { return _serviceType; }
        }
        public object Instance { get; set; }
        public InstanceScopeType InstanceScopeType { get; set; }
        public object[] BindingConstructorArguments { get; set; }
        public object[] ServiceConstructorArguments { get; set; }
        public object[] BindingAdditionalArguments { get; set; }
        public object[] ServiceAdditionalArguments { get; set; }
    }
}
