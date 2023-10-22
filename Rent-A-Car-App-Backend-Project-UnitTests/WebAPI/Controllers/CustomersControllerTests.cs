namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
{
    [TestClass]
    public class CustomersControllerTests
    {
        [TestMethod]
        public void TestGetById()
        {
            // Arrange
            var mockCustomer = new Mock<ICustomer>();
            var cust = new Cust { UserId = 1, CompanyName = "Company A" };
            mockCustomer.Setup(x => x.Get(c => c.UserId == 1)).Returns(cust);

            var customerManager = new CustomerManager(mockCustomer.Object);

            // Act
            var result = customerManager.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Customer listed successfully.", result.Message);
            Assert.AreEqual(1, result.Data.UserId); 
        }
    }
}
