using AppController.Core.Dynamic;
using AppController.Core.Modules;
using AppController.Tests.Mocks;

namespace AppController.Tests.Modules
{
    class ServiceModule : ContainerModule
    {
        public ServiceModule() : base(new Repository())
        {

        }
        public override void Load()
        {
            Bind<IWeapon>().To<Pistol>();
            Bind<IMessageService>().To<MessageService>();
            Bind<IUnit>().To<Human>();
            Bind<IWeaponComponent>().To<Muffler>();
            Bind<TestClass>().ToInstance(new TestClass());
        }
    }
}
