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
        public void GetCarByIdAsyncTest()
        {
            var sellerId = Guid.NewGuid();

            var mockAdService = new Mock<ISellerService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<SellerController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockAdService.Setup(adService => adService.GetSellerByIdAsync(sellerId)).ReturnsAsync(new Seller { Id = sellerId });
            mockMapper.Setup(mapper => mapper.Map<SellerDTO>(It.IsAny<Ad>())).Returns(new SellerDTO { Id = sellerId });
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, new Exception("Object reference not set to an instance of an object.")));

            var controller = new SellerController(mockAdService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.GetSellerByIdAsync(sellerId).Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

    }
}