// CarImagesControllerTests.cs
 
// CPSC 5210 01
 
// Purpose: Create Unit tests for CarImagesController functionality
 
using System.Collections.Generic;
 
using Core.Utilities.Result;
 
using Business.Abstract;
 
using Entities.Concrete;
 
using Entities.DTOs.CarImageDTOs;
 
using Microsoft.AspNetCore.Mvc;
 
using Microsoft.VisualStudio.TestTools.UnitTesting;
 
using Moq;
 
using WebAPI.Controllers;
namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
 
{
 
    [TestClass]
 
    public class CarImagesControllerTests
 
    {
 
        private readonly Mock<ICarImageService> _carImageServiceMock;
 
        private readonly CarImagesController _controller;
 
        public CarImagesControllerTests()
 
        {
 
            _carImageServiceMock = new Mock<ICarImageService>();
 
            _controller = new CarImagesController(_carImageServiceMock.Object);
 
        }
 
        #region Add
 
        [TestMethod]
 
        public void Adding_CarImage_Succesfully_Returns_OK()
 
        {
 
            // Arrange
 
            var carImageDto = new AddCarImageDto();
 
            var serviceResult = new SuccessResult("Image added successfully.");
 
            _carImageServiceMock.Setup(service => service.Add(carImageDto)).Returns(serviceResult);
 
            // Act
 
            IActionResult result = _controller.Add(carImageDto);
 
            // Assert
 
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
 
        }
 
        [TestMethod]
 
        public void Adding_CarImage_Unsuccesfully_Returns_BadRequest()
 
        {
 
            // Arrange
 
            var carImageDto = new AddCarImageDto();
 
            var serviceResult = new ErrorResult("Failed to add image.");
 
            _carImageServiceMock.Setup(service => service.Add(carImageDto)).Returns(serviceResult);
 
            // Act
 
            IActionResult result = _controller.Add(carImageDto);
 
            // Assert
 
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
 
        }
 
        #endregion
 
        #region Delete
 
        [TestMethod]
 
        public void Deleting_CarImage_Succesfully_Returns_OK()
 
        {
 
            // Arrange
 
            int imageId = 1;
 
            var serviceResult = new SuccessResult("Image deleted successfully.");
 
            _carImageServiceMock.Setup(service => service.Delete(It.IsAny<CarImage>())).Returns(serviceResult);
 
            // Act
 
            IActionResult result = _controller.Delete(imageId);
 
            // Assert
 
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
 
        }
 
        [TestMethod]
 
        public void Deleting_CarImage_Unsuccesfully_Returns_BadRequest()
 
        {
 
            // Arrange
 
            int imageId = 1;
 
            var serviceResult = new ErrorResult("Failed to delete image.");
 
            _carImageServiceMock.Setup(service => service.Delete(It.IsAny<CarImage>())).Returns(serviceResult);
 
            // Act
 
            IActionResult result = _controller.Delete(imageId);
 
            // Assert
 
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
 
        }
 
        #endregion
 
        #region Update
 
        [TestMethod]
 
        public void Updating_CarImage_Succesfully_Returns_OK()
 
        {
 
            // Arrange
 
            var carImageDto = new UpdateCarImageDto();
 
            var serviceResult = new SuccessResult("Image updated successfully.");
 
            _carImageServiceMock.Setup(service => service.Update(carImageDto)).Returns(serviceResult);
 
            // Act
 
            IActionResult result = _controller.Update(carImageDto);
 
            // Assert
 
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
 
        }
 
        [TestMethod]
 
        public void Updating_CarImage_Unsuccesfully_Returns_BadRequest()
 
        {
 
            // Arrange
 
            var carImageDto = new UpdateCarImageDto();
 
            var serviceResult = new ErrorResult("Failed to update image.");
 
            _carImageServiceMock.Setup(service => service.Update(carImageDto)).Returns(serviceResult);
 
            // Act
 
            IActionResult result = _controller.Update(carImageDto);
 
            // Assert
 
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
 
        }
 
        #endregion
 
        #region GetCarsById
 
        [TestMethod]
        public void Getting_CarImages_By_CarId_Returns_OK()
        {
            // Arrange
            int carId = 1;
            var serviceResult = new SuccessDataResult<List<CarImage>>(new List<CarImage>(), "Image retrieved successfully.");
            _carImageServiceMock.Setup(service => service.GetImageByCarId(carId)).Returns((IDataResult<List<CarImage>>)serviceResult);
 
            // Act
            IActionResult result = _controller.GetCarsById(carId);
 
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
            Assert.AreEqual("Image retrieved successfully.", ((OkObjectResult)result).Value);
        }
 
        [TestMethod]
        public void Getting_CarImages_By_CarId_Unsuccessfully_Returns_BadRequest()
        {
            // Arrange
            int carId = 1;
            var serviceResult = new ErrorDataResult<List<CarImage>>("Failed to retrieve images.");
            _carImageServiceMock.Setup(service => service.GetImageByCarId(carId)).Returns((IDataResult<List<CarImage>>)serviceResult);
 
            // Act
            IActionResult result = _controller.GetCarsById(carId);
 
            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
            Assert.AreEqual("Failed to retrieve images.", ((BadRequestObjectResult)result).Value);
        }
 
        #endregion
 
    }
 
}
