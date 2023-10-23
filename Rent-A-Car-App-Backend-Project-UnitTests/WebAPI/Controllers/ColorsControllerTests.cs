// AuthControllerTests.cs
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

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
{
    [TestClass]
    public class ColorsControllerTests
    {
       
       
        private readonly Mock<IColorService> _colorServiceMock;
        
        private readonly ColorsController _controller;



        public ColorsControllerTests()
        {
            _colorServiceMock = new Mock<IColorService>();
            
            _controller = new ColorsController(_colorServiceMock.Object);
        }
        [TestMethod]
        public void When_Color_Exists_GetById_Returns_OK()
        {
            // Arrange
            int id = 1;
            var color = new Color { Id = id, Name = "Color1" };
            var serviceResult = new SuccessDataResult<Color>(color);
            _colorServiceMock.Setup(service => service.GetById(id)).Returns(serviceResult);

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
            var color = new Color { Id = id, Name = "Color1" };
            var serviceResult = new ErrorDataResult<Color>(color);
            _colorServiceMock.Setup(service => service.GetById(id)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetById(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }

    }
}
