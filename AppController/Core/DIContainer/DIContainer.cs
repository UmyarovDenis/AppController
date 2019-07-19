using System;
using AppController.Core.Activation;
using AppController.Core.Dynamic;
using AppController.Core.Modules;

namespace AppController.Core.DIContainer
{
    public class DIContainer : BindableBase, IContainerCore
    {
        private IModule _module;
        private readonly IImplementor _implementor;

        public DIContainer(IModule module) : base(module.Bindings)
        {
            _module = module;
            _module.Load();
            _implementor = new Implementor(this);
            Bind<IContainerCore>().ToInstance(this);
        }
        public IModule Mudule
        {
            get { return _module; }
            set { _module = value; }
        }
        public TInstance ResolveInstance<TInstance>()
        {
            IBinding binding = _module.Bindings.GetBinding<TInstance>();

            if (binding?.Instance != null)
                return (TInstance)binding.Instance;

            return default(TInstance);
        }
        public TImplementation ResolveInterface<TImplementation>()
        {
            return _implementor.CreateInstance<TImplementation>();
        }

        public object ResolveInterface(Type bindingType)
        {
            return _implementor.CreateInstance(bindingType);
        }
    }
}
