
#nullable enable
using AutoMapper;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
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

        public AdController(IAdService adService, IMapper mapper, ILogger<AdController> logger)
        {
            _adService = adService;
            _mapper = mapper;
            _logger = logger;
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
#if DEBUG
                return StatusCode(500, e.Message + Environment.NewLine + e.StackTrace);
#endif
#if RELEASE
                return StatusCode(500, e.Message);
#endif
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
#if DEBUG
                return StatusCode(500, e.Message + Environment.NewLine + e.StackTrace);
#endif
#if RELEASE
                return StatusCode(500, e.Message);
#endif
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
#if DEBUG
                return StatusCode(500, e.Message + Environment.NewLine + e.StackTrace);
#endif
#if RELEASE
                return StatusCode(500, e.Message);
#endif
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
#if DEBUG
                return StatusCode(500, e.Message + Environment.NewLine + e.StackTrace);
#endif
#if RELEASE
                return StatusCode(500, e.Message);
#endif
            }

        }
    }
}