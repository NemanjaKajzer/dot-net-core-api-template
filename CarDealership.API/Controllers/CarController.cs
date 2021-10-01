
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.API.Controllers

{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {

        private readonly ICarService _carService;

        public CarController(ICarService carService)
        {
            _carService = carService;
        }


        [HttpGet]
        public IEnumerable<Car> Get()
        {
            return _carService.GetAll();
        }

        [HttpPost]
        public async Task<Car> AddCar(CarDTO carDto)
        {
            return await _carService.AddCar(carDto);
        }
    }
}