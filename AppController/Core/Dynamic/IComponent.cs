namespace AppController.Core.Dynamic
{
    public interface IComponent
    {
        IConfiguration<TImplementation> To<TImplementation>();
        void ToInstance(object instance);
    }
}
