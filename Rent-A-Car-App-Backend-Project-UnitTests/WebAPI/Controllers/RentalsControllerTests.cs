// RentalsControllerTests.cs
// CPSC 5210   oftware Testing and Deugging
// Purpose: Create Unit tests for Add,Update,Delete,CarAvailale and List functionality in RentalsController.cs


using AutoMapper;
using Business.Abstract;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs.RentalDTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
{
    [TestClass]
    public class RentalsControllerTests
    {
        private readonly Mock<IRentalService> _rentalServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly RentalsController _controller;

        public RentalsControllerTests()
        {
            _rentalServiceMock = new Mock<IRentalService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new RentalsController(_rentalServiceMock.Object);
        }



        #region Rental Add
        [TestMethod]
        public void Add_Rental_Data_Success_Ok()
        {
            // Arrange
            var mockUserRepository = new Mock<IRentalService>();
            var mockResult = new Mock<IResult>();
            mockResult.Setup(r => r.Success).Returns(true);
            mockResult.Setup(r => r.Message).Returns("Rental Car added successfully");

            mockUserRepository.Setup(ur => ur.Add(It.IsAny<Rental>())).Returns(mockResult.Object);

            var validUser = new Rental { Id = 1, CarId = 1, CustomerId = 1, RentDate = DateTime.Now, ReturnDate = DateTime.Now.AddDays(3) };

            // Act
            var result = mockUserRepository.Object.Add(validUser);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Rental Car added successfully", result.Message);

        }

        [TestMethod]
        public void Add_Rental_Data_Success_True()
        {
            var rental = new Rental
            {
                Id = 1,
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(3)
            };


            Assert.AreEqual(1, rental.Id);
            Assert.AreEqual(1, rental.CarId);
            Assert.AreEqual(1, rental.CustomerId);
            Assert.IsTrue(rental.RentDate < rental.ReturnDate);
        }

        [TestMethod]
        public void Add_Rental_Data_Failure_Invalid_Message()
        {
            // Arrange
            var mockRentalService = new Mock<IRentalService>();
            var mockResult = new Mock<IResult>();
            mockResult.Setup(r => r.Success).Returns(false);
            mockResult.Setup(r => r.Message).Returns("Failed to add rental car");

            mockRentalService.Setup(rs => rs.Add(It.IsAny<Rental>())).Returns(mockResult.Object);

            var invalidRental = new Rental
            {
                Id = 1,
                CarId = 1,
                CustomerId = 1,
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(3)
            };

            // Act
            var result = mockRentalService.Object.Add(invalidRental);

            // Assert
            Assert.IsFalse(result.Success);
            Assert.AreEqual("Failed to add rental car", result.Message);
        }

        #endregion

        #region Update Rental
        [TestMethod]
        public void Updating_Rental_Succesfully_Returns_OK()
        {
            // Arrange
            var rentalCarToUpdate = new Rental();
            var serviceResult = new SuccessResult();

            _rentalServiceMock.Setup(service => service.Update(rentalCarToUpdate)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Update(rentalCarToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Updating_Rental_Unsuccesfully_Returns_BadRequest()
        {
            // Arrange
            var rentalCarToUpdate = new Rental();
            var serviceResult = new ErrorResult();

            _rentalServiceMock.Setup(service => service.Update(rentalCarToUpdate)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Update(rentalCarToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region Delete
        [TestMethod]
        public void Deleting_Rental_Succesfully_Returns_OK()
        {
            // Arrange
            var rentalCarToUpdate = new Rental();
            var serviceResult = new SuccessResult();

            _rentalServiceMock.Setup(service => service.Delete(rentalCarToUpdate)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Delete(rentalCarToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }


        #endregion
        #region Get Rental List
        [TestMethod]
        public void Rental_GetListRentalDetails_Sucess()
        {
            // Arrange
            var rentalServiceMock = new Mock<IRentalService>();
            var rentalDetails = new List<GetRentalDetailDTO>
        {
            new GetRentalDetailDTO { Id = 1,
                CarName = "Car",
                CustomerName= "Name",
                RentDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(3)},
            
        };

            rentalServiceMock.Setup(rs => rs.GetListRentalDetails()).Returns(new DataResult<List<GetRentalDetailDTO>>(rentalDetails, true, "Rental details retrieved."));

            // Act
            var result = rentalServiceMock.Object.GetListRentalDetails();

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Rental details retrieved.", result.Message);
            CollectionAssert.AreEqual(rentalDetails, result.Data);
        }
        #endregion
        #region Rental Get By ID
        [TestMethod]
        public void Rental_GetById_Returns_Success_OK()
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
        #endregion
        #region Car Availale
        [TestMethod]
        public void Rental_IsCarAvailable_Returns_Success_OK()
        {
            // Arrange
            var carServiceMock = new Mock<IRentalService>();
            carServiceMock.Setup(cs => cs.IsCarAvailable(It.IsAny<int>())).Returns(new Result(true, "Car is available."));

            int carId = 1; 

            // Act
            var result = carServiceMock.Object.IsCarAvailable(carId);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Car is available.", result.Message);


        }
        #endregion

    }
}