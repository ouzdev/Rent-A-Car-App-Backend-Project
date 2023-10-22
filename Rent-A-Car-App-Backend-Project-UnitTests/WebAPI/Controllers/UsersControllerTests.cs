using Moq;
using Business.Abstract;
using Core.Utilities.Result;
using Core.Entities.Concrete;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.Controllers
{

    [TestClass]
    public class UserServiceTests
    {
        private IUserService _userService;

        [TestMethod]
        public void Add_ReturnsSuccessResult_ok()
        {   // Arrange
            var mockUserService = new Mock<IUserService>();
            var mockResult = new SuccessResult("User added successfully");
            mockUserService.Setup(ur => ur.Add(It.IsAny<User>())).Returns(mockResult);



            var userController = new UsersController(mockUserService.Object);
            var validUser = new User { FirstName = "Anusha Panta", LastName = "Panta" };



            // Act
            var actionResult = userController.Add(validUser);
            var okResult = actionResult as OkObjectResult;



            // Assert
            Assert.IsNotNull(okResult);
            var successResult = okResult.Value as SuccessResult;
            Assert.IsNotNull(successResult);
            Assert.IsTrue(successResult.Success);
            Assert.AreEqual("User added successfully", successResult.Message);
        }



        [TestMethod]
        public void Add_ReturnsSuccessResult()
        {
            // Arrange
            var mockUserRepository = new Mock<IUserService>();
            var mockResult = new Mock<IResult>();
            mockResult.Setup(r => r.Success).Returns(true);
            mockResult.Setup(r => r.Message).Returns("User added successfully");

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

        [TestMethod]
        public void UpdateData_ValidUser()
        {
            
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(u => u.Update(It.IsAny<User>())).Returns(new Result(true, "User updated successfully"));
            _userService = userServiceMock.Object;
            User validUser = new User
            {
                Id = 1,
                FirstName = "Anushaaaa",
                LastName = "Panta",
                Email = "test@gmail.com",
                Status = true
            };

            // Act
            IResult result = _userService.Update(validUser);

            // Assert
            Assert.IsTrue(result.Success);
        }

        [TestMethod]
        public void DeleteData_ValidUser()
        {
            
            var userServiceMock = new Mock<IUserService>();
            userServiceMock.Setup(u => u.Delete(It.IsAny<User>())).Returns(new Result(true, "User deleted successfully"));
            _userService = userServiceMock.Object;

            User validUser = new User
            {
                Id = 1,
                FirstName = "Anusha",
                LastName = "Panta",
                Email = "test1@gmail.com",
                Status = true
            };

            // Act
            IResult result = _userService.Delete(validUser);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("User deleted successfully", result.Message);
        }

        [TestMethod]
        public void GetAll_ReturnsAllUsers()
        {                          
                var userServiceMock = new Mock<IUserService>();
                var userList = new List<User> {
                   
                };
                userServiceMock.Setup(u => u.GetAll()).Returns(new DataResult<List<User>>(userList, true, "Data retrieved"));
                _userService = userServiceMock.Object;

                // Act
                IDataResult<List<User>> result = _userService.GetAll();

                // Assert
                Assert.IsNotNull(result.Data);
                
            

            
        }
        [TestMethod]
        public void GetByMail_ExistingEmail_ReturnsUser()
        {
            // Arrange
            string existingEmail = "test1@gmail.com";

            var userServiceMock = new Mock<IUserService>();
            var expectedUser = new User
            {
                Id = 1, 
                Email = existingEmail,
                
            };
            userServiceMock.Setup(us => us.GetByMail(existingEmail)).Returns(new DataResult<User>(expectedUser, true, "User retrieved"));

           
            _userService = userServiceMock.Object;

            // Act
            IDataResult<User> result = _userService.GetByMail(existingEmail);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.IsNotNull(result.Data);
        }


        [TestMethod]
        public void GetClaims_ReturnsClaims()
        {
            // Arrange
            var userClaimServiceMock = new Mock<IUserService>();
            User user = new User { Id = 1};
            var expectedClaims = new List<OperationClaim>
            {
                new OperationClaim { Id = 1, Name = "Claim1" },
            };
            userClaimServiceMock.Setup(service => service.GetClaims(user)).Returns(new DataResult<List<OperationClaim>>(expectedClaims, true, "Claims retrieved"));

            // Act
            var result = userClaimServiceMock.Object.GetClaims(user);

            // Assert
            Assert.IsTrue(result.Success);
            Assert.AreEqual("Claims retrieved", result.Message);
            Assert.IsNotNull(result.Data);
            Assert.AreEqual(expectedClaims.Count, result.Data.Count);
            
        }
    }
}





    
    
    
 
