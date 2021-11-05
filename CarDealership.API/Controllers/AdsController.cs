
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
    public class AdsController : ControllerBase
    {

        private readonly IAdService _adService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IResponseStatus _responseStatus;

        public AdsController(IAdService adService, IMapper mapper, ILogger<AdsController> logger, IResponseStatus responseStatus)
        {
            _adService = adService;
            _mapper = mapper;
            _logger = logger;
            _responseStatus = responseStatus;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAdByIdAsync(int id, string? promoCode)
        {
            try
            {
                if (id == 0) return BadRequest("The id should be greater than 0.");

                var ad = await _adService.GetAdByIdAsync(id, promoCode);
                var adPresentation = _mapper.Map<AdPresentationDTO>(ad);

                if (ad.Id == 0)
                {
                    _logger.LogInformation("Could not find Ad with Id: " + id);
                    return NotFound();
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
                return Created("/api/ads", ad);
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

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAdAsync(int id)
        {
            try
            {
                if (id == 0) return BadRequest("The id should be greater than 0.");

                var ad = await _adService.DeleteAdAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return _responseStatus.CustomStatusCode(500, e);
            }

        }
    }
}