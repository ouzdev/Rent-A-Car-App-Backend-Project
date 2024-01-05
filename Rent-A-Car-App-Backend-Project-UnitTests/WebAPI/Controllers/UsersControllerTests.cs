// UsersControllerTests.cs
// CPSC 5210 01
// Purpose: Create Unit tests for GetById, GetAll, Add, Update, and Delete functionality in UsersController.cs

using AutoMapper;
using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Result;
using Entities.Concrete;
using Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebAPI.Controllers;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
{
    [TestClass]
    public class UsersControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly UsersController _controller;

        public UsersControllerTests()
        {
            _userServiceMock = new Mock<IUserService>();
            _mapperMock = new Mock<IMapper>();
            _controller = new UsersController(_userServiceMock.Object);
        }

        #region GetById
        [TestMethod]
        public void When_User_Exists_GetById_Returns_OK()
        {
            // Arrange
            int id = 0;
            var user = new User { Id = id, FirstName = "BName" };
            var serviceResult = new SuccessDataResult<User>(user);
            _userServiceMock.Setup(service => service.GetById(id)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetById(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void When_User_Does_Not_Exist_GetById_Returns_BadRequestResult()
        {
            // Arrange
            int id = 0;
            var serviceResult = new ErrorDataResult<User>();
            _userServiceMock.Setup(service => service.GetById(id)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetById(id);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region GetAll
        [TestMethod]
        public void When_Users_Exist_GetAll_Returns_OK()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 0, FirstName = "B0" },
                new User { Id = 1, FirstName = "B1" },
            };
            var serviceResult = new SuccessDataResult<List<User>>(users);
            _userServiceMock.Setup(service => service.GetAll()).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void When_Users_Do_Not_Exist_GetAll_Returns_BadRequest()
        {
            // Arrange
            var users = new List<User>
            {
                new User { Id = 0, FirstName = "B0" },
                new User { Id = 1, FirstName = "B1" },
            };
            var serviceResult = new ErrorDataResult<List<User>>(users);
            _userServiceMock.Setup(service => service.GetAll()).Returns(serviceResult);

            // Act
            IActionResult result = _controller.GetAll();

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region Add
        [TestMethod]
        public void Adding_Mapped_user_Succesfully_Returns_OK()
        {
            // Arrange
            int id = 0;
            var user = new User { Id = id };
            var serviceResult = new SuccessDataResult<User>(user);
            _userServiceMock.Setup(service => service.Add(user)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Add(user);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }


        [TestMethod]
        public void Adding_Mapped_user_Unsuccesfully_Returns_BadRequest()
        {
            // Arrange
            int id = 0;
            var user = new User { Id = id };
            var serviceResult = new ErrorDataResult<User>(user);
            _userServiceMock.Setup(service => service.Add(user)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Add(user);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region Update
        [TestMethod]
        public void Updating_User_Succesfully_Returns_OK()
        {
            // Arrange
            var userToUpdate = new User();
            var serviceResult = new SuccessResult();

            _userServiceMock.Setup(service => service.Update(userToUpdate)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Update(userToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Updating_User_Unsuccesfully_Returns_BadRequest()
        {
            // Arrange
            var userToUpdate = new User();
            var serviceResult = new ErrorResult();

            _userServiceMock.Setup(service => service.Update(userToUpdate)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Update(userToUpdate);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion

        #region Delete
        [TestMethod]
        public void Deleting_User_Succesfully_Returns_OK()
        {
            // Arrange
            var userToDelete = new User();
            var serviceResult = new SuccessResult();

            _userServiceMock.Setup(service => service.Delete(userToDelete)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Delete(userToDelete);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkObjectResult));
        }

        [TestMethod]
        public void Deleteing_User_Unsuccesfully_Returns_BadRequest()
        {
            // Arrange
            var userToDelete = new User();
            var serviceResult = new ErrorResult();

            _userServiceMock.Setup(service => service.Delete(userToDelete)).Returns(serviceResult);

            // Act
            IActionResult result = _controller.Delete(userToDelete);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
        #endregion
    }
}