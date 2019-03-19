using AppController.Infrastructure.Enums;
using System;

namespace AppController.Core.Dynamic
{
    public interface IBinding
    {
        Type BindingType { get; }
        Type ServiceType { get; }
        object Instance { get; set; }
        InstanceScopeType InstanceScopeType { get; set; }
        object[] BindingConstructorArguments { get; set; }
        object[] ServiceConstructorArguments { get; set; }
    }
}
