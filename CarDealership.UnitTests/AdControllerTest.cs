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
    public class AdControllerTest
    {

        [Fact]
        public void GetCarByIdAsyncTest()
        {
            var adId = Guid.NewGuid();

            var mockAdService = new Mock<IAdService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<AdController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockAdService.Setup(adService => adService.GetAdByIdAsync(adId, null)).ReturnsAsync(new Ad { Id = adId });
            mockMapper.Setup(mapper => mapper.Map<AdPresentationDTO>(It.IsAny<Ad>())).Returns(new AdPresentationDTO { Id = adId });
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, new Exception("Object reference not set to an instance of an object.")));

            var controller = new AdController(mockAdService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.GetAdByIdAsync(adId, null).Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

    }
}