using AppController.Infrastructure.Enums;

namespace AppController.Core.Dynamic
{
    public interface IConfiguration<T>
    {
        IConfiguration<T> SetScope(InstanceScopeType instanceType);
        void WithArguments(params object[] args);
    }
}
