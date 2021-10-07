
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
    public class CarController : ControllerBase
    {

        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IResponseStatus _responseStatus;

        public CarController(ICarService carService, IMapper mapper, ILogger<CarController> logger, IResponseStatus responseStatus)
        {
            _carService = carService;
            _mapper = mapper;
            _logger = logger;
            _responseStatus = responseStatus;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetCarByIdAsync(Guid id)
        {
            try
            {
                var car = await _carService.GetCarByIdAsync(id);
                var carDTO = _mapper.Map<CarDTO>(car);

                if (car.Id.Equals(Guid.Empty))
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
        public async Task<IActionResult> AddCarAsync(CarDTO carDto)
        {
            try
            {
                var car = await _carService.AddCarAsync(carDto);
                return Ok(car);
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


        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteCarAsync(Guid id)
        {
            try
            {
                var car = await _carService.DeleteCarAsync(id);
                return Ok(car);
            }
            catch (Exception e)
            {
                _logger.LogError("Car could not be deleted. " + e.Message);
                return _responseStatus.CustomStatusCode(500, e);
            }
            
        }
    }
}