using Moq;
using Business.Abstract;
using Core.Utilities.Result;
using Core.Entities.Concrete;

using Microsoft.AspNetCore.Mvc;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
{

    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void Add_ReturnsSuccessResult()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserService>();
            var mockResult = new Mock<IResult>();
            mockResult.Setup(r => r.Success).Returns(true);
            mockResult.Setup(r => r.Message).Returns("New User is added successfully");

            mockUserRepository.Setup(ur => ur.Add(It.IsAny<User>())).Returns(mockResult.Object);

            var validUser = new User { FirstName = "Anusha panta", LastName = "Panta" };

            // Act
            var result = mockUserRepository.Object.Add(validUser);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("User added successfully", result.Message);
        }

        [TestMethod]
        public void AddData()
        {
            var User = new User
            {
                Id = 1,
                FirstName = "Anusha",
                LastName = "Panta",
                Email = "test@gmail.com",
                Status = false
            };

            User.Status = true;

            Assert.IsTrue(User.Status);

        }
    }
}





    
    
    
 
