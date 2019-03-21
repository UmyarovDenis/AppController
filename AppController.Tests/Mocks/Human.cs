using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppController.Tests.Mocks
{
    class Human : IUnit
    {
        private IWeapon weapon;
        private IMessageService message;
        private int age;

        public Human(IWeapon weapon, IMessageService message, int age = 64)
        {
            this.weapon = weapon;
            this.message = message;
            this.age = age;
        }
        public string UnitType { get; set; } = "Human";
        public IWeapon Weapon
        {
            get { return this.weapon; }
        }
        public IMessageService Service
        {
            get { return this.message; }
        }
        public int Age
        {
            get { return this.age; }
        }
    }
}
