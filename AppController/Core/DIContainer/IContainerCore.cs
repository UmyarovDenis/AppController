using AppController.Core.Modules;
using System;

namespace AppController.Core.DIContainer
{
    public interface IContainerCore
    {
        IModule Mudule { get; set; }
        TImplementation ResolveInterface<TImplementation>();
        object ResolveInterface(Type bindingType);
        TInstance ResolveInstance<TInstance>();
    }
}
