using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebAPI;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using WebAPI.Controllers;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI
{
    [TestClass]
    public class StartupTests
    {
        [TestMethod]
        public void ConfigureServices_ShouldConfigureServices()
        {
            // Arrange
            var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string> {})
            .Build();
            var services = new ServiceCollection();
            var startup = new Startup(configuration);

            // Act
            startup.ConfigureServices(services);
            
            // Assert
            var serviceProvider = services.BuildServiceProvider();
            var controller = serviceProvider.GetService<CustomersController>();
            Assert.IsNull(controller);
        }

        [TestMethod]
        public void Configure_ShouldConfigureMiddleware()
        {
            // Arrange
            var app = new Mock<IApplicationBuilder>();
            var env = new Mock<IWebHostEnvironment>();
            var configuration = new ConfigurationBuilder()
            .AddInMemoryCollection(new Dictionary<string, string> { /* Add configuration key-value pairs */ })
            .Build();
            var services = new ServiceCollection();
            var serviceProvider = services.BuildServiceProvider();
            var startup = new Startup(configuration);

            // Act
            startup.Configure(app.Object, env.Object);

            // Assert
            app.Verify(a => a.UseDeveloperExceptionPage(), Times.Never());
        }
    }
}

