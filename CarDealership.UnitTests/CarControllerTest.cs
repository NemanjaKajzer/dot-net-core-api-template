using AutoMapper;
using CarDealership.API.Controllers;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Threading.Tasks;
using CarDealership.API.Common.Response;
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
            var mockResponse = new Mock<IResponseStatus>();

            mockCarService.Setup(carService => carService.GetCarByIdAsync(carId)).ReturnsAsync(new Car { Id = carId });
            mockMapper.Setup(mapper => mapper.Map<CarDTO>(It.IsAny<Car>())).Returns(new CarDTO { Id = carId });
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, new Exception("Object reference not set to an instance of an object.")));

            var controller = new CarController(mockCarService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

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
            var mockResponse = new Mock<IResponseStatus>();

            mockCarService.Setup(carService => carService.AddCarAsync(expectedDTO)).ReturnsAsync(new Car { Id = carId });
            mockMapper.Setup(mapper => mapper.Map<CarDTO>(It.IsAny<Car>())).Returns(expectedDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, new Exception("Object reference not set to an instance of an object.")));

            var controller = new CarController(mockCarService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.AddCarAsync(expectedDTO).Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateCarAsyncTest()
        {
            var carId = Guid.NewGuid();
            var inputDTO = new CarDTO { Id = carId, Brand = "Changed"};
            var notValidDTO = new CarDTO { Brand = "Changed" };

            var mockCarService = new Mock<ICarService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<CarController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockCarService.Setup(carService => carService.UpdateCarAsync(inputDTO)).ReturnsAsync(new Car { Id = carId });
            mockMapper.Setup(mapper => mapper.Map<CarDTO>(It.IsAny<Car>())).Returns(inputDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new CarController(mockCarService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.UpdateCarAsync(inputDTO).Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateCarInvalidAsyncTest()
        {
            var carId = Guid.NewGuid();
            var notValidDTO = new CarDTO { Brand = "Changed" };

            var mockCarService = new Mock<ICarService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<CarController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockCarService.Setup(carService => carService.UpdateCarAsync(notValidDTO)).ThrowsAsync(new Exception("Object reference not set to an instance of an object."));
            mockMapper.Setup(mapper => mapper.Map<CarDTO>(It.IsAny<Car>())).Returns(notValidDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new CarController(mockCarService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.UpdateCarAsync(notValidDTO).Result as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }

        [Fact]
        public void DeleteCarAsyncTest()
        {
            var carId = Guid.NewGuid();
            var expectedDTO = new CarDTO { Id = carId };
            var car = new Car {Id = carId};

            var mockCarService = new Mock<ICarService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<CarController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockCarService.Setup(carService => carService.GetCarByIdAsync(carId)).ReturnsAsync(car);
            mockCarService.Setup(carService => carService.DeleteCarAsync(It.IsAny<Guid>())).ReturnsAsync(car);

            mockMapper.Setup(mapper => mapper.Map<CarDTO>(It.IsAny<Car>())).Returns(expectedDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new CarController(mockCarService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.DeleteCarAsync(carId).Result as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void DeleteCarInvalidAsyncTest()
        {
            var invalidId = Guid.NewGuid();
            var expectedDTO = new CarDTO { Id = invalidId };

            var mockCarService = new Mock<ICarService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<CarController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockCarService.Setup(carService => carService.DeleteCarAsync(invalidId)).ThrowsAsync(new Exception("Object reference not set to an instance of an object."));

            mockMapper.Setup(mapper => mapper.Map<CarDTO>(It.IsAny<Car>())).Returns(expectedDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new CarController(mockCarService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.DeleteCarAsync(invalidId).Result as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }
    }
}
