using AutoMapper;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDealership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public SellerController(ISellerService sellerService, IMapper mapper, ILogger<SellerController> logger)
        {
            _sellerService = sellerService;
            _mapper = mapper;
            _logger = logger;
        }


        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetSellerByIdAsync(Guid id)
        {
            var seller = await _sellerService.GetSellerByIdAsync(id);
            var sellerDTO = _mapper.Map<SellerDTO>(seller);

            if (seller == null)
            {
                _logger.LogInformation("Could not find Seller with Id: " + id);
                return NotFound();
            }

            return Ok(sellerDTO);
        }

        [HttpPost]
        public async Task<SellerDTO> AddSellerAsync(SellerDTO sellerDTO)
        {
            var seller = await _sellerService.AddSellerAsync(sellerDTO);
            return _mapper.Map<SellerDTO>(seller);
        }

        [HttpPut]
        public async Task<SellerDTO> UpdateSellerAsync(SellerDTO sellerDTO)
        {
            var seller = await _sellerService.UpdateSellerAsync(sellerDTO);
            return _mapper.Map<SellerDTO>(seller);
        }


        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<SellerDTO>> DeleteSellerAsync(Guid id)
        {
            var seller = await _sellerService.DeleteSellerAsync(id);
            return _mapper.Map<SellerDTO>(seller);
        }
    }
}
