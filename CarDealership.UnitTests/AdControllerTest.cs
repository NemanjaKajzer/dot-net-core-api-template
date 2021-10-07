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
        public void GetAdByIdAsyncTest()
        {
            var adId = Guid.NewGuid();

            var mockAdService = new Mock<IAdService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<AdController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockAdService.Setup(adService => adService.GetAdByIdAsync(adId, null)).ReturnsAsync(new Ad { Id = adId });
            mockMapper.Setup(mapper => mapper.Map<AdPresentationDTO>(It.IsAny<Ad>())).Returns(new AdPresentationDTO { Id = adId });
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new AdController(mockAdService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.GetAdByIdAsync(adId, null).Result as OkObjectResult;
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void AddAdAsyncTest()
        {
            var adId = Guid.NewGuid();
            var expectedDTO = new AdCreationDTO() { Id = adId };

            var mockAdService = new Mock<IAdService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<AdController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockAdService.Setup(sellerService => sellerService.AddAdAsync(expectedDTO)).ReturnsAsync(new Ad { Id = adId });
            mockMapper.Setup(mapper => mapper.Map<AdCreationDTO>(It.IsAny<Ad>())).Returns(expectedDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, new Exception("Object reference not set to an instance of an object.")));

            var controller = new AdController(mockAdService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.AddAdAsync(expectedDTO).Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateAdAsyncTest()
        {
            var adId = Guid.NewGuid();
            var inputDTO = new AdCreationDTO { Id = adId, Description = "Changed" };

            var mockAdService = new Mock<IAdService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<AdController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockAdService.Setup(sellerService => sellerService.UpdateAdAsync(inputDTO)).ReturnsAsync(new Ad { Id = adId });
            mockMapper.Setup(mapper => mapper.Map<AdCreationDTO>(It.IsAny<Ad>())).Returns(inputDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new AdController(mockAdService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.UpdateAdAsync(inputDTO).Result as OkObjectResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void UpdateAdInvalidAsyncTest()
        {
            var notValidDTO = new AdCreationDTO { Description = "Changed" };

            var mockAdService = new Mock<IAdService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<AdController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockAdService.Setup(adService => adService.UpdateAdAsync(notValidDTO)).ThrowsAsync(new Exception("Object reference not set to an instance of an object."));
            mockMapper.Setup(mapper => mapper.Map<AdCreationDTO>(It.IsAny<Ad>())).Returns(notValidDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new AdController(mockAdService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.UpdateAdAsync(notValidDTO).Result as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }

        [Fact]
        public void DeleteAdAsyncTest()
        {
            var adId = Guid.NewGuid();
            var expectedDTO = new AdCreationDTO { Id = adId };
            var ad = new Ad { Id = adId };

            var mockAdService = new Mock<IAdService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<AdController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockAdService.Setup(adService => adService.GetAdByIdAsync(adId, null)).ReturnsAsync(ad);
            mockAdService.Setup(adService => adService.DeleteAdAsync(It.IsAny<Guid>())).ReturnsAsync(ad);

            mockMapper.Setup(mapper => mapper.Map<AdCreationDTO>(It.IsAny<Ad>())).Returns(expectedDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new AdController(mockAdService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.DeleteAdAsync(adId).Result as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
        }

        [Fact]
        public void DeleteAdInvalidAsyncTest()
        {
            var invalidId = Guid.NewGuid();
            var expectedDTO = new AdCreationDTO { Id = invalidId };

            var mockAdService = new Mock<IAdService>();
            var mockMapper = new Mock<IMapper>();
            var mockLogger = new Mock<ILogger<AdController>>();
            var mockResponse = new Mock<IResponseStatus>();

            mockAdService.Setup(adService => adService.DeleteAdAsync(invalidId)).ThrowsAsync(new Exception("Object reference not set to an instance of an object."));

            mockMapper.Setup(mapper => mapper.Map<AdCreationDTO>(It.IsAny<Ad>())).Returns(expectedDTO);
            mockResponse.Setup(response =>
                response.CustomStatusCode(500, It.IsAny<Exception>())).Returns(new StatusCodeResult(500));

            var controller = new AdController(mockAdService.Object, mockMapper.Object, mockLogger.Object, mockResponse.Object);

            var result = controller.DeleteAdAsync(invalidId).Result as StatusCodeResult;

            Assert.NotNull(result);
            Assert.Equal(500, result.StatusCode);
        }


    }
}