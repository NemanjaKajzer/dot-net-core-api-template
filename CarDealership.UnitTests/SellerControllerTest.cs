using AutoMapper;
using CarDealership.API.Controllers;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using CarDealership.API.Common.Response;
using Microsoft.Extensions.Logging;
using Xunit;

namespace CarDealership.UnitTests
{
    public class SellerControllerTest
    {
        [Fact]
        public void GetSellerByIdAsyncTest()
        {
            var sellerId = Guid.NewGuid();

            var mockSellerService = new Mock<ISellerService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<SellerController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockSellerService.Setup(adService => adService.GetSellerByIdAsync(sellerId)).ReturnsAsync(new Seller { Id = sellerId });
            mockMapper.Setup(mapper => mapper.Map<SellerDTO>(It.IsAny<Ad>())).Returns(new SellerDTO { Id = sellerId });
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, new Exception("Object reference not set to an instance of an object.")));

            var controller = new SellerController(mockSellerService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.GetSellerByIdAsync(sellerId).Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }


        [Fact]
        public void AddSellerAsyncTest()
        {
            var sellerId = Guid.NewGuid();
            var expectedDTO = new SellerDTO() { Id = sellerId };

            var mockSellerService = new Mock<ISellerService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<SellerController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockSellerService.Setup(sellerService => sellerService.AddSellerAsync(expectedDTO)).ReturnsAsync(new Seller { Id = sellerId });
            mockMapper.Setup(mapper => mapper.Map<SellerDTO>(It.IsAny<Seller>())).Returns(expectedDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, new Exception("Object reference not set to an instance of an object.")));

            var controller = new SellerController(mockSellerService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.AddSellerAsync(expectedDTO).Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateSellerAsyncTest()
        {
            var sellerId = Guid.NewGuid();
            var inputDTO = new SellerDTO { Id = sellerId, Name = "Changed" };

            var mockSellerService = new Mock<ISellerService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<SellerController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockSellerService.Setup(sellerService => sellerService.UpdateSellerAsync(inputDTO)).ReturnsAsync(new Seller { Id = sellerId });
            mockMapper.Setup(mapper => mapper.Map<SellerDTO>(It.IsAny<Seller>())).Returns(inputDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new SellerController(mockSellerService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.UpdateSellerAsync(inputDTO).Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateSellerInvalidAsyncTest()
        {
            var notValidDTO = new SellerDTO { Name = "Changed" };

            var mockSellerService = new Mock<ISellerService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<SellerController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockSellerService.Setup(carService => carService.UpdateSellerAsync(notValidDTO)).ThrowsAsync(new Exception("Object reference not set to an instance of an object."));
            mockMapper.Setup(mapper => mapper.Map<SellerDTO>(It.IsAny<Seller>())).Returns(notValidDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new SellerController(mockSellerService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.UpdateSellerAsync(notValidDTO).Result as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }

        [Fact]
        public void DeleteCarAsyncTest()
        {
            var sellerId = Guid.NewGuid();
            var expectedDTO = new SellerDTO { Id = sellerId };
            var seller = new Seller { Id = sellerId };

            var mockSellerService = new Mock<ISellerService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<SellerController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockSellerService.Setup(carService => carService.GetSellerByIdAsync(sellerId)).ReturnsAsync(seller);
            mockSellerService.Setup(carService => carService.DeleteSellerAsync(It.IsAny<Guid>())).ReturnsAsync(seller);

            mockMapper.Setup(mapper => mapper.Map<SellerDTO>(It.IsAny<Seller>())).Returns(expectedDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new SellerController(mockSellerService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.DeleteSellerAsync(sellerId).Result as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void DeleteSellerInvalidAsyncTest()
        {
            var invalidId = Guid.NewGuid();
            var expectedDTO = new SellerDTO { Id = invalidId };

            var mockSellerService = new Mock<ISellerService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<SellerController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockSellerService.Setup(carService => carService.DeleteSellerAsync(invalidId)).ThrowsAsync(new Exception("Object reference not set to an instance of an object."));

            mockMapper.Setup(mapper => mapper.Map<SellerDTO>(It.IsAny<Seller>())).Returns(expectedDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new SellerController(mockSellerService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.DeleteSellerAsync(invalidId).Result as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }

    }
}