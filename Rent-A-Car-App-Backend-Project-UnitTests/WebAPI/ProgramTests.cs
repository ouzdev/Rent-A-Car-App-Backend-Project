// ProgramTests.cs
// CPSC 5210 01 Software Testing and Debugging
// Purpose: Create Unit tests for building host in Program.cs
using WebAPI;

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

