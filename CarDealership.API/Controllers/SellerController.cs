using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using Microsoft.AspNetCore.JsonPatch;

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
        public async Task<SellerDTO> GetSellerByIdAsync(Guid id)
        {
            var seller = await _sellerService.GetSellerByIdAsync(id);
            return _mapper.Map<SellerDTO>(seller);
        }

        [HttpPost]
        public async Task<SellerDTO> AddSellerAsync(SellerDTO sellerDTO)
        {
            var seller = await _sellerService.AddSellerAsync(sellerDTO);
            return _mapper.Map<SellerDTO>(seller);
        }

        //[HttpPatch("{id}")]
        //public async Task<SellerDTO> UpdateSellerAsync(Guid id, [FromBody] JsonPatchDocument<Seller> patchDoc)
        //{
        //    var seller = await _sellerService.UpdateSellerAsync(id, patchDoc);
        //    return _mapper.Map<SellerDTO>(seller);
        //}

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
