// BrandsControllerTests.cs
// CPSC 5210 01
// Purpose: Create Unit tests for GetById, GetAll, Add, Update, and Delete functionality in BrandsController.cs

using AutoMapper;
using Business.Abstract;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs.BrandDTOs;
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
        public void When_Brand_Does_Not_Exist_GetById_Returns_BadRequestResult()
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

        #region GetAll
        [TestMethod]
        public void When_Brands_Exist_GetAll_Returns_OK()
        {
            // Arrange
            var brands = new List<Brand>
            {
                new Brand { Id = 0, Name = "B0" },
                new Brand { Id = 1, Name = "B1" },
            };
            var serviceResult = new SuccessDataResult<List<Brand>>(brands);
            _brandServiceMock.Setup(service => service.GetAll()).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void When_Brands_Do_Not_Exist_GetAll_Returns_BadRequest()
        {
            // Arrange
            var brands = new List<Brand>
            {
                new Brand { Id = 0, Name = "B0" },
                new Brand { Id = 1, Name = "B1" },
            };
            var serviceResult = new ErrorDataResult<List<Brand>>(brands);
            _brandServiceMock.Setup(service => service.GetAll()).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region Add
        [TestMethod]
        public void Adding_Mapped_Brand_Succesfully_Returns_OK()
        {
            // Arrange
            var brandToAdd = new AddBrandDto { Name = "B0" }; 
            var mappedBrand = new Brand(); 
            _mapperMock.Setup(mapper => mapper.Map<Brand>(brandToAdd)).Returns(mappedBrand);
            var serviceResult = new SuccessDataResult<Brand>(mappedBrand);
            _brandServiceMock.Setup(service => service.Add(mappedBrand)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Add(brandToAdd);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }


        [TestMethod]
        public void Adding_Mapped_Brand_Unsuccesfully_Returns_BadRequest()
        {
            // Arrange
            var brandToAdd = new AddBrandDto { Name = "B0" };
            var mappedBrand = new Brand(); 
            _mapperMock.Setup(mapper => mapper.Map<Brand>(brandToAdd)).Returns(mappedBrand);
            var serviceResult = new ErrorDataResult<Brand>(mappedBrand);
            _brandServiceMock.Setup(service => service.Add(mappedBrand)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Add(brandToAdd);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region Update
        [TestMethod]
        public void Updating_Brand_Succesfully_Returns_OK()
        {
            // Arrange
            var brandToUpdate = new Brand(); 
            var serviceResult = new SuccessResult();

            _brandServiceMock.Setup(service => service.Update(brandToUpdate)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Update(brandToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Updating_Brand_Unsuccesfully_Returns_BadRequest()
        {
            // Arrange
            var brandToUpdate = new Brand(); 
            var serviceResult = new ErrorResult();

            _brandServiceMock.Setup(service => service.Update(brandToUpdate)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Update(brandToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region Delete
        [TestMethod]
        public void Deleting_Brand_Succesfully_Returns_OK()
        {
            // Arrange
            var brandToDelete = new Brand();
            var serviceResult = new SuccessResult();

            _brandServiceMock.Setup(service => service.Delete(brandToDelete)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Delete(brandToDelete);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Deleteing_Brand_Unsuccesfully_Returns_BadRequest()
        {
            // Arrange
            var brandToDelete = new Brand();
            var serviceResult = new ErrorResult();

            _brandServiceMock.Setup(service => service.Delete(brandToDelete)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Delete(brandToDelete);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion
    }
}