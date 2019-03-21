using System;
using System.Collections.Generic;
using System.Reflection;

namespace AppController.Core.Activation
{
    public interface IInjector
    {
        object Inject(Type instanceType, object[] additionalArgs = null);
        TInstance Inject<TInstance>(Type instanceType);
        void InjectValues(object instance, IEnumerable<FieldInfo> injectedFields);
    }
}
