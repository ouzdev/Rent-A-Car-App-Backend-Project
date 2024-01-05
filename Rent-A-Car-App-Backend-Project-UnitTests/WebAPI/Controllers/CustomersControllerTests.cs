// CustomersControllerTests.cs
// CPSC 5210 01
// Purpose: Create Unit tests for GetById, GetAll, Add, Update, and Delete functionality in customersController.cs

using Business.Abstract;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Moq;
using Entities.Concrete;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
{
    [TestClass]
    public class CustomersControllerTests
    {
        private readonly Mock<ICustomerService> _customerServiceMock;
        private readonly CustomersController _controller;

        public CustomersControllerTests()
        {
            _customerServiceMock = new Mock<ICustomerService>();
            _controller = new CustomersController(_customerServiceMock.Object);
        }

        #region GetById
        [TestMethod]
        public void When_customer_Exists_GetById_Returns_OK()
        {
            // Arrange
            int id = 0;
            var customer = new Customer { Id = id};
            var serviceResult = new SuccessDataResult<Customer>(customer);
            _customerServiceMock.Setup(service => service.GetById(id)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetById(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void When_customer_Does_Not_Exist_GetById_Returns_BadRequestResult()
        {
            // Arrange
            int id = 0;
            var serviceResult = new ErrorDataResult<Customer>();
            _customerServiceMock.Setup(service => service.GetById(id)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetById(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region GetAll
        [TestMethod]
        public void When_customers_Exist_GetAll_Returns_OK()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = 0 },
                new Customer { Id = 1 },
            };
            var serviceResult = new SuccessDataResult<List<Customer>>(customers);
            _customerServiceMock.Setup(service => service.GetAll()).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void When_customers_Do_Not_Exist_GetAll_Returns_BadRequest()
        {
            // Arrange
            var customers = new List<Customer>
            {
                new Customer { Id = 0 },
                new Customer { Id = 1 },
            };
            var serviceResult = new ErrorDataResult<List<Customer>>(customers);
            _customerServiceMock.Setup(service => service.GetAll()).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region Add
        [TestMethod]
        public void Adding_Mapped_customer_Succesfully_Returns_OK()
        {
            // Arrange
            int id = 0;
            var customer = new Customer { Id = id };
            var serviceResult = new SuccessDataResult<Customer>(customer);
            _customerServiceMock.Setup(service => service.Add(customer)).Returns(serviceResult);
            
            // Act
            IActionResult result = _controller.Add(customer);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }


        [TestMethod]
        public void Adding_Mapped_customer_Unsuccesfully_Returns_BadRequest()
        {
            // Arrange
            int id = 0;
            var customer = new Customer { Id = id };
            var serviceResult = new ErrorDataResult<Customer>(customer);
            _customerServiceMock.Setup(service => service.Add(customer)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Add(customer);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region Update
        [TestMethod]
        public void Updating_customer_Succesfully_Returns_OK()
        {
            // Arrange
            var customerToUpdate = new Customer();
            var serviceResult = new SuccessResult();

            _customerServiceMock.Setup(service => service.Update(customerToUpdate)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Update(customerToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Updating_customer_Unsuccesfully_Returns_BadRequest()
        {
            // Arrange
            var customerToUpdate = new Customer();
            var serviceResult = new ErrorResult();

            _customerServiceMock.Setup(service => service.Update(customerToUpdate)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Update(customerToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region Delete
        [TestMethod]
        public void Deleting_customer_Succesfully_Returns_OK()
        {
            // Arrange
            var customerToDelete = new Customer();
            var serviceResult = new SuccessResult();

            _customerServiceMock.Setup(service => service.Delete(customerToDelete)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Delete(customerToDelete);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Deleteing_customer_Unsuccesfully_Returns_BadRequest()
        {
            // Arrange
            var customerToDelete = new Customer();
            var serviceResult = new ErrorResult();

            _customerServiceMock.Setup(service => service.Delete(customerToDelete)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Delete(customerToDelete);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion
    }
}
