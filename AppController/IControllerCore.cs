using AppController.Core.Controller;
using AppController.Core.DIContainer;

namespace AppController
{
    public interface IControllerCore : IController
    {
        IContainerCore Container { get; }
    }
}
