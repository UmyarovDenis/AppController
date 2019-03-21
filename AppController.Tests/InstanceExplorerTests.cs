using AppController.Core.Activation;
using AppController.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace AppController.Tests
{
    [TestClass]
    public class InstanceExplorerTests
    {
        [TestMethod]
        public void InstancesHasDefaultConstructor_IsTrue()
        {
            bool isDefaultConstructorSword = InstanceExplorer.HasDefaultConstructor(typeof(Sword));

            Assert.IsTrue(isDefaultConstructorSword);
        }
        [TestMethod]
        public void InstancesHasDefaultConstructor_IsFalse()
        {
            bool isNotDefaultConstructorHuman = InstanceExplorer.HasDefaultConstructor(typeof(Human));
            bool isNotDefaultConstructorTestClass = InstanceExplorer.HasDefaultConstructor(typeof(TestClass));

            Assert.IsFalse(isNotDefaultConstructorHuman);
            Assert.IsFalse(isNotDefaultConstructorTestClass);
        }
        [TestMethod]
        public void GetNonOptionalParameters_Getted()
        {
            var humanConstructor = typeof(Human).GetConstructors().First();
            var nonOptionalParameters = InstanceExplorer.GetNonOptionalParameters(humanConstructor).ToList();
            var parameters = InstanceExplorer.GetParameters(humanConstructor);

            Assert.IsNotNull(parameters);
            Assert.AreEqual(parameters.Count() - 1, nonOptionalParameters.Count());
        }
        [TestMethod]
        public void GetOrderedConstructorList_Getted()
        {
            var constructorList = InstanceExplorer.GetOrderedConstructorList(typeof(TestClass));
            
            for(int i = 0; i < constructorList.Count(); i++)
            {
                if((i + 1) < constructorList.Count())
                {
                    int constructorParametersCount = constructorList[i].GetParameters().Count();
                    int nextConstructorParametersCount = constructorList[i + 1].GetParameters().Count();

                    Assert.AreEqual(constructorParametersCount - 1, nextConstructorParametersCount);
                }
            }
        }
    }
}
