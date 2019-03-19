namespace AppController.Core.Dynamic
{
    public interface IBindableBase
    {
        IComponent Bind<T>();
        IComponent Unbind<T>();
        IComponent Rebind<T>();
    }
}
