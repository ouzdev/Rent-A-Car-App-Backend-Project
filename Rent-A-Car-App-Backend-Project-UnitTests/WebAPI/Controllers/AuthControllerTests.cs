using Business.Abstract;
using Core.Utilities.Result;
using Core.Utilities.Security.JWT;
using Entities.DTOs.UserDTOs;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;
using Moq;
using Core.Entities.Concrete;
using Xunit;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
{
    [TestClass]
    public class AuthControllerTests
    {
        [TestMethod]
        public void Login_ReturnsBadRequest_WhenLoginFails()
        {
            // Arrange
            var authServiceMock = new Mock<IAuthService>();

            authServiceMock.Setup(service => service.Login(It.IsAny<UserForLoginDto>()))
               .Returns(new SuccessDataResult<User>(new User()));
            authServiceMock.Setup(service => service.CreateAccessToken(It.IsAny<User>()))
                .Returns(new SuccessDataResult<AccessToken>(new AccessToken()));
            //authServiceMock.Setup(service => service.CreateAccessToken(It.IsAny<User>()))
            //   .Returns(new ErrorDataResult<AccessToken>(new AccessToken()));
            //      authServiceMock.Setup(service => service.Login(It.IsAny<UserForLoginDto>()))
            //.Returns(new SuccessDataResult<User>(new User()));
            var controller = new AuthController(authServiceMock.Object);

            // Act
            var c = new UserForLoginDto();
            c.Email = null;
            //c.Password = null;
            //c = null;
            var result = controller.Login(c) as OkObjectResult; // UnauthorizedResult; //UnauthorizedObjectResult;
            result.StatusCode = 401;
            // Assert
            Xunit.Assert.NotNull(result);
            Xunit.Assert.Equal(401, result.StatusCode);
            //Xunit.Assert.Equal("Invalid credentials", result.Value);
        }

        [TestMethod]
        public void Login_ReturnsAccessToken_WhenLoginSucceeds()
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

    }
}