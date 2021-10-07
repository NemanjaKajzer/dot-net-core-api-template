
#nullable enable
using AutoMapper;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CarDealership.API.Common.Response;
using Microsoft.Extensions.Logging;

namespace CarDealership.API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class AdController : ControllerBase
    {

        private readonly IAdService _adService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IResponseStatus _responseStatus;

        public AdController(IAdService adService, IMapper mapper, ILogger<AdController> logger, IResponseStatus responseStatus)
        {
            _adService = adService;
            _mapper = mapper;
            _logger = logger;
            _responseStatus = responseStatus;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetAdByIdAsync(Guid id, string? promoCode)
        {
            try
            {
                var ad = await _adService.GetAdByIdAsync(id, promoCode);
                var adPresentation = _mapper.Map<AdPresentationDTO>(ad);

                if (ad.Id == Guid.Empty)
                {
                    _logger.LogInformation("Could not find Ad with Id: " + id);
                    return NoContent();
                }

                return Ok(adPresentation);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not retrieve Ad with Id: " + id + Environment.NewLine + e.Message);
                return _responseStatus.CustomStatusCode(500, e);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddAdAsync(AdCreationDTO adCreationDTO)
        {
            try
            {
                var ad = await _adService.AddAdAsync(adCreationDTO);
                return Created("/api/Ad", ad);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not add Ad. " + e.Message);
                return _responseStatus.CustomStatusCode(500, e);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAdAsync(AdCreationDTO adCreationDTO)
        {
            try
            {
                var ad = await _adService.UpdateAdAsync(adCreationDTO);
                return Ok(ad);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not update Ad: " + adCreationDTO.Id);
                return _responseStatus.CustomStatusCode(500, e);
            }
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAdAsync(Guid id)
        {
            try
            {
                var ad = await _adService.DeleteAdAsync(id);
                return Ok(ad);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return _responseStatus.CustomStatusCode(500, e);
            }

        }
    }
}