using System;

namespace AppController.Core.Dynamic
{
    public class BindableBase : IBindableBase
    {
        protected readonly IBindingRepository _bindingRepository;

        public BindableBase(IBindingRepository repository)
        {
            _bindingRepository = repository;
        }
        public IComponent Bind<T>()
        {
            return new Component(_bindingRepository, typeof(T));
        }
        public IComponent Rebind<T>()
        {
            throw new NotImplementedException();
        }
        public IComponent Unbind<T>()
        {
            throw new NotImplementedException();
        }
    }
}
