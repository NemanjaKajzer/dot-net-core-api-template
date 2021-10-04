using CarDealership.API.Controllers;
using CarDealership.Business.Interfaces;
using CarDealership.Model.Entities;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace CarDealership.UnitTests
{
    public class CarControllerTest
    {
        [Fact]
        public void GetAllTest()
        {
            //var mockCarService = new Mock<ICarService>();
            //mockCarService.Setup(carService => carService.GetAll()).Returns(new List<Car>(){ new() { Brand = "Brand" } });

            //var controller = new CarController(mockCarService.Object);

            //var result = controller.Get();

            //Assert.Single(result);
        }
    }
}
