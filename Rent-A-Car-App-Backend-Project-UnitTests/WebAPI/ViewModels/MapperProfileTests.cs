// MapperProfileTests.cs
// CPSC 5210 01 Software Testing and Debugging
// Purpose: Create Unit tests for AddBrandTo Mapper functionality based on name


using AutoMapper;
using WebAPI.ViewModels;
using Entities.Concrete;
using Entities.DTOs.BrandDTOs;

namespace Rent_A_Car_App_Backend_Project_UnitTests.WebAPI.ViewModels
{
    [TestClass]
    public class MapperProfileTests
    {
        [TestMethod]
        public void Using_AddBrandDto_To_Brand_Mapping_Should_Return_IsValid_Brand_Name()
        {
            // Arrange
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile<MapperProfile>());
            var mapper = new Mapper(configuration);
            var addBrandDto = new AddBrandDto { Name = "b1" };

            // Act
            var brand = mapper.Map<Brand>(addBrandDto);

            // Assert
            Assert.AreEqual(addBrandDto.Name, brand.Name);
        }
    }
}
