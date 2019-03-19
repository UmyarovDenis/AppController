using System;
using AppController.Core.DIContainer;
using AppController.Core.Dynamic;
using AppController.Core.Modules;
using AppController.Tests.Mocks;
using AppController.Tests.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppController.Tests
{
    [TestClass]
    public class ContainerTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            IContainerCore containerCore = new DIContainer(new ServiceModule());

            IUnit unit = containerCore.ResolveInterface<IUnit>();
            Assert.IsNotNull(unit);
            Assert.IsNotNull(unit.Service);
            Assert.IsNotNull(unit.Weapon);
            Assert.IsNotNull(unit.UnitType);
        }
    }
}
