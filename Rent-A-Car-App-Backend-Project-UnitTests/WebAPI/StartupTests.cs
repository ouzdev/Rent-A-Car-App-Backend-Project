// StartupTests.cs
// CPSC 5210 01 Software Testing and Debugging
// Purpose: Create Unit tests for condigurinf services in StartupTests.cs

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using WebAPI;
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
    }
}

