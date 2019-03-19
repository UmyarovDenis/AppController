namespace AppController.Core.Dynamic
{
    public interface IComponent
    {
        IConfiguration<TImplementation> To<TImplementation>();
        IConfiguration<TInstance> ToInstance<TInstance>(TInstance instance);
    }
}
