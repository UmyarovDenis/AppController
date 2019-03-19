using AppController.Core.Controller;
using AppController.Core.Dynamic;

namespace AppController.Core.Modules
{
    public abstract class ControllerModule : ViewRegister, IModule
    {
        private readonly IBindingRepository _bindings;

        public ControllerModule(IBindingRepository bindings) : base(bindings)
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
