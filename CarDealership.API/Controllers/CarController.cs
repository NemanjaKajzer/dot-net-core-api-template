
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
    public class CarController : ControllerBase
    {

        private readonly ICarService _carService;
        private readonly IMapper _mapper;

        public CarController(ICarService carService, IMapper mapper)
        {
            _carService = carService;
            _mapper = mapper;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetCarByIdAsync(Guid id)
        {
            var car = await _carService.GetCarByIdAsync(id);
            var carDTO = _mapper.Map<CarDTO>(car);

            if (car.Id.Equals(Guid.Empty))
            {
                return NotFound();
            }

            return Ok(carDTO);
        }

        [HttpPost]
        public async Task<CarDTO> AddCarAsync(CarDTO carDto)
        {
            var car = await _carService.AddCarAsync(carDto);
            return _mapper.Map<CarDTO>(car);
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