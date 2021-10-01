
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Common.Enums;
using CarDealership.Model.Entities;
using Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.API.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class AdController : ControllerBase
    {

        private readonly IAdService _adService;

        public AdController(IAdService adService)
        {
            _adService = adService;
        }


        [HttpGet]
        public IActionResult Get()
        {
            var adds = _adService.GetAll();

            return Ok(adds);
        }

        [HttpGet("getdiscounted")]
        public async Task<IActionResult> Get(Guid id, Guid discountId)
        {
            var ad = await _adService.GetById(id, discountId);

            if (ad == null)
                return NotFound();

            return Ok(ad);
        }
    }
}