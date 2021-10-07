using AutoMapper;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using CarDealership.API.Common.Response;
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
        private readonly IResponseStatus _responseStatus;

        public SellerController(ISellerService sellerService, IMapper mapper, ILogger<SellerController> logger, IResponseStatus responseStatus)
        {
            _sellerService = sellerService;
            _mapper = mapper;
            _logger = logger;
            _responseStatus = responseStatus;
        }


        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetSellerByIdAsync(Guid id)
        {
            try
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
            catch (Exception e)
            {
                return _responseStatus.CustomStatusCode(500, e);
            }

        }

        [HttpPost]
        public async Task<IActionResult> AddSellerAsync(SellerDTO sellerDTO)
        {
            try
            {
                var seller = await _sellerService.AddSellerAsync(sellerDTO);
                return Created("/api/seller", seller);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not add Seller. " + e.Message);
                return _responseStatus.CustomStatusCode(500, e);
            }

        }

        [HttpPut]
        public async Task<IActionResult> UpdateSellerAsync(SellerDTO sellerDTO)
        {
            try
            {
                var seller = await _sellerService.UpdateSellerAsync(sellerDTO);
                return Ok(seller);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not update Seller. " + e.Message);
                return _responseStatus.CustomStatusCode(500, e);
            }

        }


        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteSellerAsync(Guid id)
        {
            try
            {
                var seller = await _sellerService.DeleteSellerAsync(id);
                return Ok(seller);
            }
            catch (Exception e)
            {
                _logger.LogError("Could not delete Seller. " + e.Message);
                return _responseStatus.CustomStatusCode(500, e);
            }

        }
    }
}
