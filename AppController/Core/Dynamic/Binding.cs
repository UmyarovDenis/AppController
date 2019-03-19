using AppController.Infrastructure.Enums;
using System;

namespace AppController.Core.Dynamic
{
    public class Binding : IBinding
    {
        private Type _bindingType;
        private Type _serviceType;
        private object _instance;
        private InstanceScopeType _instanceScopeType;
        private object[] _bindingConstructorArguments;
        private object[] _serviceConstructorArguments;

        public Binding(Type bindingType, Type serviceType)
        {
            _bindingType = bindingType;
            _serviceType = serviceType;
            _instanceScopeType = InstanceScopeType.PerCall;
        }
        public Binding(Type bindingType, object instance) : this(bindingType, instance.GetType())
        {
            _instance = instance;
        }
        public Type BindingType
        {
            get { return _bindingType; }
        }
        public Type ServiceType
        {
            get { return _serviceType; }
        }
        public object Instance
        {
            get { return _instance; }
            set { _instance = value; }
        }
        public InstanceScopeType InstanceScopeType
        {
            get { return _instanceScopeType; }
            set { _instanceScopeType = value; }
        }
        public object[] BindingConstructorArguments
        {
            get { return _bindingConstructorArguments; }
            set { _bindingConstructorArguments = value; }
        }
        public object[] ServiceConstructorArguments
        {
            get { return _serviceConstructorArguments; }
            set { _serviceConstructorArguments = value; }
        }
    }
}
