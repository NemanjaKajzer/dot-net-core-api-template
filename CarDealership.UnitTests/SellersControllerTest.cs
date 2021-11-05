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
    public class SellersControllerTest
    {
        [Fact]
        public void GetSellerByIdAsyncTest()
        {
            var sellerId = 1;

            var mockSellerService = new Mock<ISellerService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<SellersController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockSellerService.Setup(adService => adService.GetSellerByIdAsync(sellerId)).ReturnsAsync(new Seller { Id = sellerId });
            mockMapper.Setup(mapper => mapper.Map<SellerDTO>(It.IsAny<Ad>())).Returns(new SellerDTO { Id = sellerId });
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, new Exception("Object reference not set to an instance of an object.")));

            var controller = new SellersController(mockSellerService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.GetSellerByIdAsync(sellerId).Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }


        [Fact]
        public void AddSellerAsyncTest()
        {
            var sellerId = 1;
            var expectedDTO = new SellerDTO() { Id = sellerId };

            var mockSellerService = new Mock<ISellerService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<SellersController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockSellerService.Setup(sellerService => sellerService.AddSellerAsync(expectedDTO)).ReturnsAsync(new Seller { Id = sellerId });
            mockMapper.Setup(mapper => mapper.Map<SellerDTO>(It.IsAny<Seller>())).Returns(expectedDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, new Exception("Object reference not set to an instance of an object.")));

            var controller = new SellersController(mockSellerService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.AddSellerAsync(expectedDTO).Result as CreatedResult;

            Assert.NotNull(result.Value);
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public void UpdateSellerAsyncTest()
        {
            var sellerId = 1;
            var inputDTO = new SellerDTO { Id = sellerId, Name = "Changed" };

            var mockSellerService = new Mock<ISellerService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<SellersController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockSellerService.Setup(sellerService => sellerService.UpdateSellerAsync(inputDTO)).ReturnsAsync(new Seller { Id = sellerId });
            mockMapper.Setup(mapper => mapper.Map<SellerDTO>(It.IsAny<Seller>())).Returns(inputDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new SellersController(mockSellerService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

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
            var mockLogger = new Mock<ILogger<SellersController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockSellerService.Setup(carService => carService.UpdateSellerAsync(notValidDTO)).ThrowsAsync(new Exception("Object reference not set to an instance of an object."));
            mockMapper.Setup(mapper => mapper.Map<SellerDTO>(It.IsAny<Seller>())).Returns(notValidDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new SellersController(mockSellerService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.UpdateSellerAsync(notValidDTO).Result as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }

        [Fact]
        public void DeleteSellerAsyncTest()
        {
            var sellerId = 1;
            var expectedDTO = new SellerDTO { Id = sellerId };
            var seller = new Seller { Id = sellerId };

            var mockSellerService = new Mock<ISellerService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<SellersController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockSellerService.Setup(carService => carService.GetSellerByIdAsync(sellerId)).ReturnsAsync(seller);
            mockSellerService.Setup(carService => carService.DeleteSellerAsync(It.IsAny<int>())).ReturnsAsync(seller);

            mockMapper.Setup(mapper => mapper.Map<SellerDTO>(It.IsAny<Seller>())).Returns(expectedDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new SellersController(mockSellerService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.DeleteSellerAsync(sellerId).Result as StatusCodeResult;

            Assert.Equal(204, result.StatusCode);
        }

        [Fact]
        public void DeleteSellerInvalidAsyncTest()
        {
            var invalidId = 1;
            var expectedDTO = new SellerDTO { Id = invalidId };

            var mockSellerService = new Mock<ISellerService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<SellersController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockSellerService.Setup(carService => carService.DeleteSellerAsync(invalidId)).ThrowsAsync(new Exception("Object reference not set to an instance of an object."));

            mockMapper.Setup(mapper => mapper.Map<SellerDTO>(It.IsAny<Seller>())).Returns(expectedDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new SellersController(mockSellerService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.DeleteSellerAsync(invalidId).Result as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }

    }
}