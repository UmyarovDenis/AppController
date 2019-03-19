using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController.Tests.Mocks
{
    class Pistol : IWeapon
    {
        public Pistol(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
