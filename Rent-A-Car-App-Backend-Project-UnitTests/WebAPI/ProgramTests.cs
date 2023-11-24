using Moq;
using WebAPI;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void Creating_Host_Builder_Should_Configure_Host_Builder()
        {
            // Arrange
            var args = new string[] {};

            // Act
            var hostBuilder = Program.CreateHostBuilder(args);

            // Assert
            Assert.IsNotNull(hostBuilder);
        }

    }
}

