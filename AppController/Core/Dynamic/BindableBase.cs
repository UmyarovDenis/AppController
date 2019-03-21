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
            Unbind<T>();
            return new Component(_bindingRepository, typeof(T));
        }
        public void Unbind<T>()
        {
            _bindingRepository.RemoveBinding<T>();
        }
    }
}
