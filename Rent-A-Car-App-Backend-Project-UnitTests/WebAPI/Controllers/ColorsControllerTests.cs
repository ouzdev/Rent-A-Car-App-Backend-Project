// ColorsControllerTests.cs
// CPSC 5210 01
// Purpose: Create Unit tests for Login & Regsiter functionality in ColorsController.cs

using System;
using Core.Utilities.Result;
using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using WebAPI.Controllers;
using AutoMapper;
using System.Runtime.InteropServices;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
{
    [TestClass]
    public class ColorsControllerTests
    {
       
        private readonly Mock<IColorService> _ColorServiceMock;
        private readonly ColorsController _controller;

        public ColorsControllerTests()
        {
            _ColorServiceMock = new Mock<IColorService>();
            
            _controller = new ColorsController(_ColorServiceMock.Object);
        }
        
        #region GetID
            
        [TestMethod]
        public void When_Color_Exists_GetById_Returns_OK()
        {
            // Arrange
            int id = 1;
            var Color = new Color { Id = id, Name = "Color1" };
            var serviceResult = new SuccessDataResult<Color>(Color);
            _ColorServiceMock.Setup(service => service.GetById(id)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetById(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void When_Color_Does_Not_Exist_GetById_Returns_BadRequestResult()
        {
            // Arrange
            int id = 1;
            var Color = new Color { Id = id, Name = "Color1" };
            var serviceResult = new ErrorDataResult<Color>(Color);
            _ColorServiceMock.Setup(service => service.GetById(id)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetById(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

        #endregion

        #region GetAll

        [TestMethod]
        public void When_Colors_Exist_GetAll_Returns_OK()
        {
            // Arrange
            var Colors = new List<Color>
            {
                new Color { Id = 0, Name = "B0" },
                new Color { Id = 1, Name = "B1" },

            };

            var serviceResult = new SuccessDataResult<List<Color>>(Colors);

            _ColorServiceMock.Setup(service => service.GetAll()).Returns(serviceResult);
            
            // Act
            IActionResult result = _controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }

        [TestMethod]
        public void When_Colors_Do_Not_Exist_GetAll_Returns_BadRequest()

        {

            // Arrange
            var Colors = new List<Color>
            {
                new Color { Id = 0, Name = "B0" },
                new Color { Id = 1, Name = "B1" },

            };

            var serviceResult = new ErrorDataResult<List<Color>>(Colors);

            _ColorServiceMock.Setup(service => service.GetAll()).Returns(serviceResult);
            
            // Act
            IActionResult result = _controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

        #endregion
        
        #region Add

        [TestMethod]
        public void Adding_Mapped_Color_Succesfully_Returns_OK()

        {

            // Arrange
            var ColorToAdd = new Color{ Name = "B0" };
            var serviceResult = new SuccessDataResult<Color>(ColorToAdd);

            _ColorServiceMock.Setup(service => service.Add(ColorToAdd)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Add(ColorToAdd);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }

        [TestMethod]
        public void Adding_Mapped_Color_Unsuccesfully_Returns_BadRequest()

        {

            // Arrange
            var ColorToAdd = new Color { Name = "B0" };  

            var serviceResult = new ErrorDataResult<Color>(ColorToAdd);

            _ColorServiceMock.Setup(service => service.Add(ColorToAdd)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Add(ColorToAdd);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }
        
        #endregion

        #region Update

        [TestMethod]
        public void Updating_Color_Succesfully_Returns_OK()

        {
            // Arrange
            var ColorToUpdate = new Color();
            var serviceResult = new SuccessResult();

            _ColorServiceMock.Setup(service => service.Update(ColorToUpdate)).Returns(serviceResult);
            
            // Act
            IActionResult result = _controller.Update(ColorToUpdate);
            
            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }



        [TestMethod]
        public void Updating_Color_Unsuccesfully_Returns_BadRequest()

        {

            // Arrange

            var ColorToUpdate = new Color();
            var serviceResult = new ErrorResult();

            _ColorServiceMock.Setup(service => service.Update(ColorToUpdate)).Returns(serviceResult);


            // Act
            IActionResult result = _controller.Update(ColorToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

        #endregion

        #region Delete

        [TestMethod]
        public void Deleting_Color_Succesfully_Returns_OK()

        {

            // Arrange
            var ColorToDelete = new Color();
            var serviceResult = new SuccessResult();

            _ColorServiceMock.Setup(service => service.Delete(ColorToDelete)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Delete(ColorToDelete);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));

        }

        [TestMethod]
        public void Deleteing_Color_Unsuccesfully_Returns_BadRequest()

        {

            // Arrange
            var ColorToDelete = new Color();
            var serviceResult = new ErrorResult();
            
            _ColorServiceMock.Setup(service => service.Delete(ColorToDelete)).Returns(serviceResult);



            // Act
            IActionResult result = _controller.Delete(ColorToDelete);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));

        }

        #endregion
    }
}
