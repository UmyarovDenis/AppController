using AppController.Infrastructure.Attributes;
using AppController.Tests.Modules;

namespace AppController.Tests.Mocks
{
    class InjectedClass
    {
        [Injected(typeof(ServiceModule))]
        private IControllerCore _controller;

        public IControllerCore Controller
        {
            get { return _controller; }
        }
    }
}
