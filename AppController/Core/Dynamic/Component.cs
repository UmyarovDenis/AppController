using System;

namespace AppController.Core.Dynamic
{
    public class Component : IComponent
    {
        protected readonly IBindingRepository _repository;
        protected readonly Type _bindingType;

        public Component(IBindingRepository repository, Type bindingType)
        {
            _repository = repository;
            _bindingType = bindingType;
        }
        public virtual IConfiguration<TImplementation> To<TImplementation>()
        {
            IBinding binding = new Binding(_bindingType, typeof(TImplementation));
            _repository.AddBinding(binding);

            return new Configuration<TImplementation>(_repository);
        }
        public virtual void ToInstance(object instance)
        {
            IBinding binding = new Binding(_bindingType, instance);
            _repository.AddBinding(binding);
        }
    }
}
