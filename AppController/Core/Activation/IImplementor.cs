using AppController.Core.Dynamic;
using System;

namespace AppController.Core.Activation
{
    public interface IImplementor : IInjector
    {
        TInstance CreateInstance<TInstance>();
        object CreateInstance(Type instanceType);
        TInstance CreateInstance<TInstance>(IBinding binding);
        object CreateInstance(Type instanceType, params object[] args);
        TInstance CreateInstance<TInstance>(Type instanceType, params object[] args);
    }
}
