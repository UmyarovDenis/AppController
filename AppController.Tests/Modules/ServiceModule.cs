using AppController.Core.Dynamic;
using AppController.Core.Modules;
using AppController.Infrastructure.Enums;
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
            Bind<IWeapon>().To<Sword>();
            Bind<IMessageService>().To<MessageService>();
            Bind<IUnit>().To<Human>();
        }
    }
}
