using AppController.Core.Dynamic;
using System;

namespace AppController.Core.Activation
{
    public interface IImplementor : IInjector
    {
        TInstance CreateInstance<TInstance>();
        TInstance CreateInstance<TInstance>(IBinding binding);
        object CreateInstance(Type instanceType);
        object CreateInstance(IBinding binding);
        object CreateInstance(Type instanceType, params object[] args);
        object CreateInstance(Type instanceType, object[] args, object[] additionalArgs);
        TInstance CreateInstance<TInstance>(Type instanceType, params object[] args);
        TInstance CreateInstance<TInstance>(Type instanceType, object[] args, object[] additionalArgs);
    }
}
