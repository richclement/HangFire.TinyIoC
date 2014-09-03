using System;
using Hangfire;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TinyIoC;

namespace HangFire.TinyIoC.Tests
{
    [TestClass]
    public class TinyIoCJobActivatorTests
    {
        private TinyIoCContainer _container;

        [TestInitialize]
        public void Setup()
        {
            _container = new TinyIoCContainer();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_ThrowsAnException_WhenContainerIsNull()
        {
            var activator = new TinyIoCJobActivator(null);
        }

        [TestMethod]
        public void Class_IsOfTypeJobActivator()
        {
            var activator = new TinyIoCJobActivator(_container);
            Assert.IsInstanceOfType(activator, typeof(JobActivator));
        }

        [TestMethod]
        public void TinyIoCJobActivator_CallsTinyIoC()
        {
            _container.Register((container, overloads) => "instance");
            var activator = new TinyIoCJobActivator(_container);

            var result = activator.ActivateJob(typeof (string));
            
            Assert.AreEqual("instance", result);
        }

        [TestMethod]
        public void UseTinyIoCActivator_PassesCorrectActivator()
        {
            var configuration = new Mock<IBootstrapperConfiguration>();
            var container = new TinyIoCContainer();

            configuration.Object.UseTinyIoCActivator(container);

            configuration.Verify(x => x.UseActivator(It.IsAny<TinyIoCJobActivator>()));
        }
    }
}
