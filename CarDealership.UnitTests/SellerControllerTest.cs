using AutoMapper;
using CarDealership.API.Controllers;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
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

            mockAdService.Setup(adService => adService.GetSellerByIdAsync(sellerId)).ReturnsAsync(new Seller { Id = sellerId });
            mockMapper.Setup(mapper => mapper.Map<SellerDTO>(It.IsAny<Ad>())).Returns(new SellerDTO { Id = sellerId });


            var controller = new SellerController(mockAdService.Object, mockMapper.Object, mockLogger.Object);

            var result = controller.GetSellerByIdAsync(sellerId).Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

    }
}