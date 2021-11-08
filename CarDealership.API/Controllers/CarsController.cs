using AutoMapper;
using CarDealership.API.Common.Response;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace CarDealership.API.Controllers

{
    [ApiController]
    [Route("api/[controller]")]
    public class CarsController : ControllerBase
    {

        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IResponseStatus _responseStatus;

        public CarsController(ICarService carService, IMapper mapper, ILogger<CarsController> logger, IResponseStatus responseStatus)
        {
            _carService = carService;
            _mapper = mapper;
            _logger = logger;
            _responseStatus = responseStatus;
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCarByIdAsync(int id)
        {
            try
            {
                var car = await _carService.GetCarByIdAsync(id);
                var carDTO = _mapper.Map<CarDTO>(car);

                if (car == null)
                {
                    _logger.LogInformation("Could not find Car with Id: " + id);
                    return NotFound();
                }

                return Ok(carDTO);
            }
            catch (Exception e)
            {
                _logger.LogError("Car could not be found. " + e.Message);
                return _responseStatus.CustomStatusCode(500, e);
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> AddCarAsync(CarDTO carDTO)
        {
            try
            {
                var car = await _carService.AddCarAsync(carDTO);
                return Created("/api/cars", car);
            }
            catch (Exception e)
            {
                _logger.LogError("Car could not be added. " + e.Message);
                return _responseStatus.CustomStatusCode(500, e);
            }

            
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateCarAsync(CarDTO carDTO)
        {
            try
            {
                var car = await _carService.UpdateCarAsync(carDTO);
                return Ok(car);
            }
            catch (Exception e)
            {
                _logger.LogError("Car could not be updated. " + e.Message);
                return _responseStatus.CustomStatusCode(500, e);
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCarAsync(int id)
        {
            try
            {
                var car = await _carService.DeleteCarAsync(id);
                return NoContent();
            }
            catch (Exception e)
            {
                _logger.LogError("Car could not be deleted. " + e.Message);
                return _responseStatus.CustomStatusCode(500, e);
            }
            
        }
    }
}