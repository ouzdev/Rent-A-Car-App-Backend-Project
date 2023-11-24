// CarsControllerTests.cs
 
using System.Collections.Generic;
 
using Core.Utilities.Result;
 
using Business.Abstract;
 
using Entities.Concrete;
 
using Microsoft.AspNetCore.Mvc;
 
using Microsoft.VisualStudio.TestTools.UnitTesting;
 
using Moq;
 
using WebAPI.Controllers;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
 
{
 
    [TestClass]
 
    public class CarsControllerTests
 
    {
 
        private readonly Mock<ICarService> _carServiceMock;
 
        private readonly CarsController _controller;
 
        public CarsControllerTests()
 
        {
 
            _carServiceMock = new Mock<ICarService>();
 
            _controller = new CarsController(_carServiceMock.Object);
 
        }
 
        #region Delete

    [TestMethod]
 
    public void Deleting_Car_Successfully_Returns_OK()
 
            {
 
                // Arrange
 
                int carId = 1;
 
                var successResult = new SuccessResult("Car deleted successfully");
 
            _carServiceMock.Setup(service => service.Delete(It.IsAny<Car>())).Returns(successResult);
 
            // Act
 
            IActionResult result = _controller.Delete(carId);
 
                // Assert
 
                Assert.IsInstanceOfType(result, typeof(OkObjectResult));
 
                Assert.AreEqual("Car deleted successfully", ((OkObjectResult)result).Value);
 
            }
 
        [TestMethod]
 
        public void Deleting_Car_Unsuccessfully_Returns_BadRequest()
 
        {
 
            // Arrange
 
            int carId = 1;
 
            var errorResult = new ErrorResult("Failed to delete car");
 
            _carServiceMock.Setup(service => service.Delete(It.IsAny<Car>())).Returns(errorResult);
 
            // Act
 
            IActionResult result = _controller.Delete(carId);
 
            // Assert
 
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
 
            Assert.AreEqual("Failed to delete car", ((BadRequestObjectResult)result).Value);
 
        }
 
        #endregion
 
        #region GetById
 
        [TestMethod]
 
        public void Getting_Car_By_Id_Returns_OK()
 
        {
 
            // Arrange
 
            int carId = 1;
 
            var serviceResult = new SuccessDataResult<Car>(new Car(), "Car retrieved successfully.");
 
            _carServiceMock.Setup(service => service.GetById(carId)).Returns((IDataResult<Car>)serviceResult);
 
            // Act
 
            IActionResult result = _controller.GetById(carId);
 
            // Assert
 
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
 
        }
 
        [TestMethod]
 
        public void Getting_Car_By_Id_Unsuccessfully_Returns_BadRequest()
 
        {
 
            // Arrange
 
            int carId = 1;
 
            var serviceResult = new ErrorResult("Failed to retrieve car.");
 
            _carServiceMock.Setup(service => service.GetById(carId)).Returns((IDataResult<Car>)serviceResult);
 
            // Act
 
            IActionResult result = _controller.GetById(carId);
 
            // Assert
 
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
 
        }
 
        #endregion
 
        #region GetCarsByColorId
 
        [TestMethod]
 
        public void Getting_Cars_By_ColorId_Returns_OK()
 
        {
 
            // Arrange
 
            int colorId = 1;
 
            var serviceResult = new SuccessDataResult<List<Car>>(new List<Car>(), "Cars retrieved successfully.");
 
            _carServiceMock.Setup(service => service.GetCarsByColorId(colorId)).Returns((IDataResult<List<Car>>)serviceResult);
 
            // Act
 
            IActionResult result = _controller.GetCarsByColorId(colorId);
 
            // Assert
 
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
 
        }
 
        [TestMethod]
 
        public void Getting_Cars_By_ColorId_Unsuccessfully_Returns_BadRequest()
 
        {
 
            // Arrange
 
            int colorId = 1;
 
            var serviceResult = new ErrorDataResult<List<Car>>("Failed to retrieve cars.");
 
            _carServiceMock.Setup(service => service.GetCarsByColorId(colorId)).Returns((IDataResult<List<Car>>)serviceResult);
 
            // Act
 
            IActionResult result = _controller.GetCarsByColorId(colorId);
 
            // Assert
 
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
 
        }
 
        #endregion
 
        #region GetCarsByBrandId
 
        [TestMethod]
 
        public void Getting_Cars_By_BrandId_Returns_OK()
 
        {
 
            // Arrange
 
            int brandId = 1;
 
            var serviceResult = new SuccessDataResult<List<Car>>(new List<Car>(), "Cars retrieved successfully.");
 
            _carServiceMock.Setup(service => service.GetCarsByBrandId(brandId)).Returns((IDataResult<List<Car>>)serviceResult);
 
            // Act
 
            IActionResult result = _controller.GetCarsByBrandId(brandId);
 
            // Assert
 
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
 
        }
 
        [TestMethod]
 
        public void Getting_Cars_By_BrandId_Unsuccessfully_Returns_BadRequest()
 
        {
 
            // Arrange
 
            int brandId = 1;
 
            var serviceResult = new ErrorDataResult<List<Car>>("Failed to retrieve cars.");
 
            _carServiceMock.Setup(service => service.GetCarsByBrandId(brandId)).Returns((IDataResult<List<Car>>)serviceResult);
 
            // Act
 
            IActionResult result = _controller.GetCarsByBrandId(brandId);
 
            // Assert
 
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
 
        }
 
        #endregion
 
    }
 
}
