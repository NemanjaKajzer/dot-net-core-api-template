
#nullable enable
using AutoMapper;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CarDealership.API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class AdController : ControllerBase
    {

        private readonly IAdService _adService;
        private readonly IMapper _mapper;

        public AdController(IAdService adService, IMapper mapper)
        {
            _adService = adService;
            _mapper = mapper;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetAdByIdAsync(Guid id, string? promoCode)
        {
            var ad = await _adService.GetAdByIdAsync(id, promoCode);
            var adPresentation = _mapper.Map<AdPresentationDTO>(ad);

            if (ad.Id == Guid.Empty)
            {
                return NotFound();
            }

            return Ok(adPresentation);
        }

        //[HttpGet("getdiscounted")]
        //public async Task<IActionResult> Get(Guid id, string)
        //{
        //    var ad = await _adService.GetAdByIdAsync(id);

        //    if (ad == null)
        //        return NotFound();

        //    return Ok(ad);
        //}

        [HttpPost]
        public async Task<AdCreationDTO> AddAdAsync(AdCreationDTO adCreationDTO)
        {
            var ad = await _adService.AddAdAsync(adCreationDTO);
            return _mapper.Map<AdCreationDTO>(ad);
        }

        [HttpPut]
        public async Task<AdCreationDTO> UpdateAdAsync(AdCreationDTO adCreationDTO)
        {
            var ad = await _adService.UpdateAdAsync(adCreationDTO);
            return _mapper.Map<AdCreationDTO>(ad);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<AdCreationDTO> DeleteAdAsync(Guid id)
        {
            var ad = await _adService.DeleteAdAsync(id);
            return _mapper.Map<AdCreationDTO>(ad);
        }
    }
}