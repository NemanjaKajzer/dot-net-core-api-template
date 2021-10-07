
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
    public class CarController : ControllerBase
    {

        private readonly ICarService _carService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CarController(ICarService carService, IMapper mapper, ILogger<CarController> logger)
        {
            _carService = carService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetCarByIdAsync(Guid id)
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

        [HttpPost]
        public async Task<CarDTO> AddCarAsync(CarDTO carDto)
        {
            try
            {
                var car = await _carService.AddCarAsync(carDto);
                return _mapper.Map<CarDTO>(car);
            }
            catch (Exception e)
            {
                _logger.LogError("Car could not be added. " + e.Message);
                return carDto;
            }

            
        }

        [HttpPatch("{id}")]
        public async Task<CarDTO> UpdateCarAsync(CarDTO carDTO)
        {
            var car = await _carService.UpdateCarAsync(carDTO);
            return _mapper.Map<CarDTO>(car);
        }


        [HttpDelete("{id:Guid}")]
        public async Task<ActionResult<CarDTO>> DeleteCarAsync(Guid id)
        {
            var car = await _carService.DeleteCarAsync(id);
            return _mapper.Map<CarDTO>(car);
        }
    }
}