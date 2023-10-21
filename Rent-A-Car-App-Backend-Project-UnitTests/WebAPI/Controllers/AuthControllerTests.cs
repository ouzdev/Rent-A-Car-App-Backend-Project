// AuthControllerTests.cs
// CPSC 5210 01
// Purpose: Create Unit tests for Login & Regsiter functionality in AuthController.cs

using Business.Abstract;
using Core.Utilities.Result;
using Core.Utilities.Security.JWT;
using Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Moq;
using Core.Entities.Concrete;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
{
    [TestClass]
    public class AuthControllerTests
    {
        #region Login
        [TestMethod]
        public void Login_Fail_Returns_Bad_Request_()
        {
            // Arrange
            var authServiceMock = new Mock<IAuthService>();
            authServiceMock.Setup(service => service.Login(It.IsAny<UserForLoginDto>()))
                .Returns(new ErrorDataResult<User>());
            var controller = new AuthController(authServiceMock.Object);

            // Act
            var result = controller.Login(new UserForLoginDto()) as BadRequestObjectResult;

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(400, result.StatusCode);
        }

        [TestMethod]
        public void Login_Success_And_Token_Creation_Failure_Returns_Bad_Request_()
        {
            // Arrange
            var authServiceMock = new Mock<IAuthService>();
            authServiceMock.Setup(service => service.Login(It.IsAny<UserForLoginDto>()))
                .Returns(new SuccessDataResult<User>());
            authServiceMock.Setup(service => service.CreateAccessToken(It.IsAny<User>()))
                .Returns(new ErrorDataResult<AccessToken>(new AccessToken()));
            var controller = new AuthController(authServiceMock.Object);

            // Act
            var result = controller.Login(new UserForLoginDto()) as BadRequestObjectResult;

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(400, result.StatusCode);
        }

        [TestMethod]
        public void Login_Success_Returns_Access_Token()
        {
            // Arrange
            var authServiceMock = new Mock<IAuthService>();
            authServiceMock.Setup(service => service.Login(It.IsAny<UserForLoginDto>()))
                .Returns(new SuccessDataResult<User>(new User()));
            authServiceMock.Setup(service => service.CreateAccessToken(It.IsAny<User>()))
                .Returns(new SuccessDataResult<AccessToken>(new AccessToken()));
            var controller = new AuthController(authServiceMock.Object);

            // Act
            var result = controller.Login(new UserForLoginDto()) as OkObjectResult;

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(200, result.StatusCode);
            Xunit.Assert.IsType<AccessToken>(result.Value);
        }
        #endregion

        #region Register
        [TestMethod]
        public void User_Does_Not_Exist_So_Register_Returns_Bad_Request()
        {
            // Arrange
            var authServiceMock = new Mock<IAuthService>();
            authServiceMock.Setup(service => service.UserExists(It.IsAny<string>()))
                .Returns(new ErrorResult());
            var controller = new AuthController(authServiceMock.Object);

            // Act
            var result = controller.Register(new UserForRegisterDto()) as BadRequestObjectResult;

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(400, result.StatusCode);
        }

        [TestMethod]
        public void Registration_Success_Returns_Access_Token()
        {
            // Arrange
            var authServiceMock = new Mock<IAuthService>();
            authServiceMock.Setup(service => service.UserExists(It.IsAny<string>()))
                .Returns(new SuccessResult());
            authServiceMock.Setup(service => service.Register(It.IsAny<UserForRegisterDto>()))
                .Returns(new SuccessDataResult<User>(new User()));
            authServiceMock.Setup(service => service.CreateAccessToken(It.IsAny<User>()))
                .Returns(new SuccessDataResult<AccessToken>(new AccessToken()));
            var controller = new AuthController(authServiceMock.Object);

            // Act
            var result = controller.Register(new UserForRegisterDto()) as OkObjectResult;

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(200, result.StatusCode);
        }

        [TestMethod]
        public void User_Exists_And_unsuccesful_Registration_Returns_Bad_Request()
        {
            // Arrange
            var authServiceMock = new Mock<IAuthService>();
            authServiceMock.Setup(service => service.UserExists(It.IsAny<string>()))
                .Returns(new SuccessResult());
            authServiceMock.Setup(service => service.Register(It.IsAny<UserForRegisterDto>()))
                .Returns(new ErrorDataResult<User>(new User()));
            var controller = new AuthController(authServiceMock.Object);

            // Act
            var result = controller.Register(new UserForRegisterDto()) as BadRequestObjectResult;

            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(400, result.StatusCode);
        }
        #endregion

    }
}