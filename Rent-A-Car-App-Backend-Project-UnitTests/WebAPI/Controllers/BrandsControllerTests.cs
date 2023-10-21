// BrandsControllerTests.cs
// CPSC 5210 01
// Purpose: Create Unit tests for GetById, GetAll, Add, Update, and Delete functionality in BrandsController.cs

using AutoMapper;
using Business.Abstract;
using Core.Utilities.Result;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
{
    [TestClass]
    public class BrandsControllerTests
    {
        private readonly Mock<IBrandService> _brandServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly BrandsController _controller;

        public BrandsControllerTests()
        {
            _brandServiceMock = new Mock<IBrandService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new BrandsController(_brandServiceMock.Object, _mapperMock.Object);
        }

        #region GetById
        [TestMethod]
        public void When_Brand_Exists_GetById_Returns_OK()
        {
            // Arrange
            int id = 0;
            var brand = new Brand { Id = id, Name = "BName" };
            var serviceResult = new SuccessDataResult<Brand>(brand);
            _brandServiceMock.Setup(service => service.GetById(id)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetById(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void When_Brand_Exists_GetById_Returns_BadRequestResult()
        {
            // Arrange
            int id = 0;
            var serviceResult = new ErrorDataResult<Brand>();
            _brandServiceMock.Setup(service => service.GetById(id)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetById(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion


    }
}