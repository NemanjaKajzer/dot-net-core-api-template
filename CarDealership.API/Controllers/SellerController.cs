using AutoMapper;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarDealership.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;
        private readonly IMapper _mapper;

        public SellerController(ISellerService sellerService, IMapper mapper)
        {
            _sellerService = sellerService;
            _mapper = mapper;
        }


        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetSellerByIdAsync(Guid id)
        {
            var seller = await _sellerService.GetSellerByIdAsync(id);
            var sellerDTO = _mapper.Map<SellerDTO>(seller);

            if (seller.Id.Equals(Guid.Empty))
            {
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
