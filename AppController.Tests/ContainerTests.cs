using AppController.Core.Activation;
using AppController.Core.DIContainer;
using AppController.Tests.Mocks;
using AppController.Tests.Modules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace AppController.Tests
{
    [TestClass]
    public class ContainerTests
    {
        private IContainerCore _container;

        [TestInitialize]
        public void Init()
        {
            _container = new DIContainer(new ServiceModule());
        }
        [TestMethod]
        public void GetImplement()
        {
            IMessageService service = _container.ResolveInterface<IMessageService>();
            Assert.IsNotNull(service);
        }
        [TestMethod]
        public void ResolveInterface_DependencyChain()
        {
            IUnit human = _container.ResolveInterface<IUnit>();

            Assert.IsNotNull(human);
            Assert.IsNotNull(human.Weapon);
            Assert.IsNotNull(human.Service);
        }
        [TestMethod]
        public void ResolverInstance()
        {
            var instance_1 = _container.ResolveInstance<TestClass>();
            var instance_2 = _container.ResolveInstance<TestClass>();

            Assert.IsNotNull(instance_1);
            Assert.IsNotNull(instance_2);
            Assert.AreEqual(instance_1.GetHashCode(), instance_2.GetHashCode());
        }
        [TestMethod]
        public void RemoveBinding()
        {
            _container.Unbind<IMessageService>();

            Assert.ThrowsException<ArgumentException>(() => _container.ResolveInterface<IMessageService>());
        }
        [TestMethod]
        public void Rebind()
        {
            IWeapon weapon = _container.ResolveInterface<IWeapon>();

            Assert.IsNotNull(weapon);
            Assert.IsInstanceOfType(weapon, typeof(Pistol));

            _container.Rebind<IWeapon>().To<Sword>();

            weapon = _container.ResolveInterface<IWeapon>();

            Assert.IsNotNull(weapon);
            Assert.IsInstanceOfType(weapon, typeof(Sword));
        }
        [TestMethod]
        public void InjectorTests()
        {
            Injector injector = new Injector(_container);

            InjectedClass injectedClass = new InjectedClass();

            if (InstanceExplorer.TryGetInjectedFields(injectedClass, out List<FieldInfo> fields))
                injector.InjectValues(injectedClass, fields);

            Assert.IsNotNull(injectedClass.Controller);
        }
    }
}
