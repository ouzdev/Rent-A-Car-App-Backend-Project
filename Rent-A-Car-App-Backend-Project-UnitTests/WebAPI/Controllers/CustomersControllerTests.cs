using Business.Abstract;
using Core.Utilities.Result;
using Core.Utilities.Security.JWT;
using Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Moq;
using Core.Entities.Concrete;

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
        [TestMethod]
        public void TestAdd()
        {
            // Arrange
            var mockCustomer = new Mock<ICustomer>();
            var customerManager = new CustomerManager(mockCustomer.Object);
            var customer = new Customer { UserId = 1, CompanyName = "Company Sample" };

            // Act
            var result = customerManager.Add(customer);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Customer add is successful.", result.Message);
        }
        [TestMethod]
        public void TestUpdate()
        {
            // Arrange
            var mockCustomer = new Mock<ICustomer>();
            var customerManager = new CustomerManager(mockCustomer.Object);
            var customer = new Customer { UserId = 1, CompanyName = "Updated Sample Company" };

            // Act
            var result = customerManager.Update(customer);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Customer update is successful.", result.Message);
        }
    }
    
}
