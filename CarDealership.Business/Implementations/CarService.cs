using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using CarDealership.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Business.Implementations
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepository;

        public CarService(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        public IEnumerable<Car> GetAll()
        {
            return _carRepository.GetAll().AsEnumerable();
        }

        public async Task<Car> AddCar(CarDTO carDto)
        {
            var newCar = new Car
            {
               Brand = carDto.Brand,
               Model = carDto.Model,
               Power = carDto.Power,
               Seats = carDto.Seats,
               Doors = carDto.Doors,
               ProductionYear = carDto.ProductionYear,
               EngineVolume = carDto.EngineVolume,
               Kilometers = carDto.Kilometers,
               TransmissionType = carDto.TransmissionType
            };

            return await _carRepository.AddAsync(newCar);

        }
    }
}