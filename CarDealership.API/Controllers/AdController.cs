
#nullable enable
using CarDealership.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using AutoMapper;
using CarDealership.Common.DTOs;

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

            if (ad == null)
                return NotFound();

            return Ok(ad);
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
    }
}