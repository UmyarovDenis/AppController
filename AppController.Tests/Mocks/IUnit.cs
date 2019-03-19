using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController.Tests.Mocks
{
    interface IUnit
    {
        string UnitType { get; set; }
        IWeapon Weapon { get; }
        IMessageService Service { get; }
    }
}
