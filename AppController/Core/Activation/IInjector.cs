using System;

namespace AppController.Core.Activation
{
    public interface IInjector
    {
        object Inject(Type instanceType);
        TInstance Inject<TInstance>(Type instanceType);
    }
}
