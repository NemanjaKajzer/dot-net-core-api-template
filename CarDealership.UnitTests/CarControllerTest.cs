using AutoMapper;
using CarDealership.API.Controllers;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using Xunit;

namespace CarDealership.UnitTests
{
    public class CarControllerTest
    {
        [Fact]
        public void GetCarByIdAsyncTest()
        {
            var carId = Guid.NewGuid();

            var mockCarService = new Mock<ICarService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<CarController>>();

            mockCarService.Setup(carService => carService.GetCarByIdAsync(carId)).ReturnsAsync(new Car { Id = carId });
            mockMapper.Setup(mapper => mapper.Map<CarDTO>(It.IsAny<Car>())).Returns(new CarDTO { Id = carId });


            var controller = new CarController(mockCarService.Object, mockMapper.Object, mockLogger.Object);

            var result = controller.GetCarByIdAsync(carId).Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void AddCarAsyncTest()
        {
            var carId = Guid.NewGuid();
            var expectedDTO = new CarDTO { Id = carId };

            var mockCarService = new Mock<ICarService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<CarController>>();

            mockCarService.Setup(carService => carService.AddCarAsync(expectedDTO)).ReturnsAsync(new Car { Id = carId });
            mockMapper.Setup(mapper => mapper.Map<CarDTO>(It.IsAny<Car>())).Returns(expectedDTO);

            var controller = new CarController(mockCarService.Object, mockMapper.Object, mockLogger.Object);

            var result = controller.AddCarAsync(expectedDTO).Result;

            Assert.NotNull(result);
            Assert.Equal(carId.ToString(), result.Id.ToString());
        }
    }
}
