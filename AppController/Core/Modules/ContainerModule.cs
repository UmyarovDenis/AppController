using AppController.Core.Dynamic;

namespace AppController.Core.Modules
{
    public abstract class ContainerModule : BindableBase, IModule
    {
        private readonly IBindingRepository _bindings;

        public ContainerModule(IBindingRepository bindings) : base(bindings)
        {
            _bindings = bindings;
        }
        public IBindingRepository Bindings
        {
            get
            {
                return _bindings;
            }
        }

        public abstract void Load();
    }
}
