// RentalsControllerTests.cs
// CPSC 5210 01
// Purpose: Create Unit tests for GetById, GetAll, Add, Update, and Delete functionality in rentalsController.cs

using Business.Abstract;
using Core.Utilities.Result;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Moq;
using Entities.Concrete;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
{
    [TestClass]
    public class RentalsControllerTests
    {
        private readonly Mock<IRentalService> _rentalServiceMock;
        private readonly RentalsController _controller;

        public RentalsControllerTests()
        {
            _rentalServiceMock = new Mock<IRentalService>();
            _controller = new RentalsController(_rentalServiceMock.Object);
        }

        #region GetById
        [TestMethod]
        public void When_rental_Exists_GetById_Returns_OK()
        {
            // Arrange
            int id = 0;
            var rental = new Rental { Id = id };
            var serviceResult = new SuccessDataResult<Rental>(rental);
            _rentalServiceMock.Setup(service => service.GetById(id)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetById(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void When_rental_Does_Not_Exist_GetById_Returns_BadRequestResult()
        {
            // Arrange
            int id = 0;
            var serviceResult = new ErrorDataResult<Rental>();
            _rentalServiceMock.Setup(service => service.GetById(id)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetById(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region GetAll
        [TestMethod]
        public void When_rentals_Exist_GetAll_Returns_OK()
        {
            // Arrange
            var rentals = new List<Rental>
            {
                new Rental { Id = 0 },
                new Rental { Id = 1 },
            };
            var serviceResult = new SuccessDataResult<List<Rental>>(rentals);
            _rentalServiceMock.Setup(service => service.GetAll()).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void When_rentals_Do_Not_Exist_GetAll_Returns_BadRequest()
        {
            // Arrange
            var rentals = new List<Rental>
            {
                new Rental { Id = 0 },
                new Rental { Id = 1 },
            };
            var serviceResult = new ErrorDataResult<List<Rental>>(rentals);
            _rentalServiceMock.Setup(service => service.GetAll()).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region Add
        [TestMethod]
        public void Adding_Mapped_rental_Succesfully_Returns_OK()
        {
            // Arrange
            int id = 0;
            var rental = new Rental { Id = id };
            var serviceResult = new SuccessDataResult<Rental>(rental);
            _rentalServiceMock.Setup(service => service.Add(rental)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Add(rental);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }


        [TestMethod]
        public void Adding_Mapped_rental_Unsuccesfully_Returns_BadRequest()
        {
            // Arrange
            int id = 0;
            var rental = new Rental { Id = id };
            var serviceResult = new ErrorDataResult<Rental>(rental);
            _rentalServiceMock.Setup(service => service.Add(rental)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Add(rental);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region Update
        [TestMethod]
        public void Updating_rental_Succesfully_Returns_OK()
        {
            // Arrange
            var rentalToUpdate = new Rental();
            var serviceResult = new SuccessResult();

            _rentalServiceMock.Setup(service => service.Update(rentalToUpdate)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Update(rentalToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Updating_rental_Unsuccesfully_Returns_BadRequest()
        {
            // Arrange
            var rentalToUpdate = new Rental();
            var serviceResult = new ErrorResult();

            _rentalServiceMock.Setup(service => service.Update(rentalToUpdate)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Update(rentalToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region Delete
        [TestMethod]
        public void Deleting_rental_Succesfully_Returns_OK()
        {
            // Arrange
            var rentalToDelete = new Rental();
            var serviceResult = new SuccessResult();

            _rentalServiceMock.Setup(service => service.Delete(rentalToDelete)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Delete(rentalToDelete);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Deleteing_rental_Unsuccesfully_Returns_BadRequest()
        {
            // Arrange
            var rentalToDelete = new Rental();
            var serviceResult = new ErrorResult();

            _rentalServiceMock.Setup(service => service.Delete(rentalToDelete)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Delete(rentalToDelete);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion
    }
}
