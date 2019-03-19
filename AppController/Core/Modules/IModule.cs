using AppController.Core.Dynamic;

namespace AppController.Core.Modules
{
    public interface IModule
    {
        IBindingRepository Bindings { get; }
        void Load();
    }
}
