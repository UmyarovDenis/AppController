using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController.Tests.Mocks
{
    class TestClass
    {
        public TestClass()
        {

        }
        public TestClass(int x, string str)
        {

        }
        public TestClass(IWeapon weapon)
        {

        }
        public TestClass(IWeapon weapon, int x = 1, string str = "simple string")
        {

        }
    }
}
