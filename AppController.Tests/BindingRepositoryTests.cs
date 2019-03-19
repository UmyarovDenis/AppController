using System;
using AppController.Core.Dynamic;
using AppController.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppController.Tests
{
    [TestClass]
    public class BindingRepositoryTests
    {
        private IBindingRepository _repository;
        private IBinding _swordBinding;

        [TestInitialize]
        public void Init()
        {
            _swordBinding = new Binding(typeof(IWeapon), typeof(Sword));

            _repository = new Repository();
        }
        [TestMethod]
        public void TryGetBindingByImplementation()
        {
            _repository.AddBinding(_swordBinding);
            IBinding binding = _repository.GetBindingByImplementation<Sword>();

            Assert.IsNotNull(binding);
        }
        [TestMethod]
        public void AddBinding()
        {
            _repository.AddBinding(_swordBinding);

            IBinding swordBinding = _repository.GetBinding<IWeapon>();

            Sword sword = new Sword();
            Type instanceType = swordBinding.ServiceType;

            Assert.IsNotNull(swordBinding);
            Assert.IsInstanceOfType(sword, instanceType);
        }
    }
}
