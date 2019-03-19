using AppController.Infrastructure.Enums;

namespace AppController.Core.Dynamic
{
    public class Configuration<T> : IConfiguration<T>
    {
        private readonly IBindingRepository _repository;

        public Configuration(IBindingRepository repository)
        {
            _repository = repository;
        }
        public IConfiguration<T> SetScope(InstanceScopeType instanceScopeType)
        {
            _repository.GetBindingByImplementation<T>().InstanceScopeType = instanceScopeType;

            return this;
        }
        public void WithArguments(params object[] args)
        {
            if(args != null)
            {
                _repository.GetBindingByImplementation<T>().ServiceConstructorArguments = args;
            }
        }
    }
}
