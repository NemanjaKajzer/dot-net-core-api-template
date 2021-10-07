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
    public class AdControllerTest
    {

        [Fact]
        public void GetCarByIdAsyncTest()
        {
            var adId = Guid.NewGuid();

            var mockAdService = new Mock<IAdService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<AdController>>();

            mockAdService.Setup(adService => adService.GetAdByIdAsync(adId, null)).ReturnsAsync(new Ad { Id = adId });
            mockMapper.Setup(mapper => mapper.Map<AdPresentationDTO>(It.IsAny<Ad>())).Returns(new AdPresentationDTO { Id = adId });


            var controller = new AdController(mockAdService.Object, mockMapper.Object, mockLogger.Object);

            var result = controller.GetAdByIdAsync(adId, null).Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

    }
}