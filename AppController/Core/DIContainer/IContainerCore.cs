using AppController.Core.Dynamic;
using AppController.Core.Modules;
using System;

namespace AppController.Core.DIContainer
{
    public interface IContainerCore : IBindableBase
    {
        IModule Mudule { get; set; }
        TImplementation ResolveInterface<TImplementation>();
        object ResolveInterface(Type bindingType);
        TInstance ResolveInstance<TInstance>();
    }
}
