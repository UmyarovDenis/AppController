using System;
using AppController.Core.Activation;
using AppController.Core.Dynamic;
using AppController.Core.Modules;
using AppController.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppController.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IControllerCore controllerCore = new ControllerCore(null, null);
        }
        [TestMethod]
        public void InstanceExplorer_GetConstructors()
        {
            var constructors = InstanceExplorer.GetOrderedConstructorList(typeof(TestClass));
        }
    }
}
