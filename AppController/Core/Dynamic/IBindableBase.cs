namespace AppController.Core.Dynamic
{
    public interface IBindableBase
    {
        IComponent Bind<T>();
        void Unbind<T>();
        IComponent Rebind<T>();
    }
}
