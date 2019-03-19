using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController.Core.Controller.Navigation
{
    public interface INavigator
    {
        INavigator GetPage<TView>();
    }
}
