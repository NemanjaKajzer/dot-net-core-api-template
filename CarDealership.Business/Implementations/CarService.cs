using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using CarDealership.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealership.Common.Enums;

namespace CarDealership.Business.Implementations
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepository;

        public CarService(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }

        public Task<Car> GetCarByIdAsync(Guid id)
        {
            return _carRepository.GetByIdAsync(id);
        }

        public Task<IEnumerable<Car>> FilterCarsAsync()
        {
            return _carRepository.FilterAsync(c => c.Brand.Equals("BMW"));
        }

        public async Task<Car> AddCarAsync(CarDTO carDto)
        {
            var newCar = new Car(carDto);

            return await _carRepository.AddAsync(newCar);
        }

        public async Task<Car> UpdateCarAsync(CarDTO carDTO)
        {
            var car = _carRepository.GetByIdAsync(carDTO.Id).Result;

            car.Brand = carDTO.Brand ?? car.Brand;
            car.Model = carDTO.Model ?? car.Model;

            car.Power = carDTO.Power == 0 ? car.Power : carDTO.Power;
            car.Seats = carDTO.Seats == 0 ? car.Seats : carDTO.Seats;
            car.Doors = carDTO.Doors == 0 ? car.Doors : carDTO.Doors;
            car.EngineVolume = carDTO.EngineVolume == 0 ? car.EngineVolume : carDTO.EngineVolume;
            car.Kilometers = carDTO.Kilometers == 0 ? car.Kilometers : carDTO.Kilometers;

            car.ProductionYear = carDTO.ProductionYear == 0 ? car.ProductionYear : carDTO.ProductionYear;

            if (carDTO.TransmissionType != TransmissionType.NOT_SET)
            {
                car.TransmissionType = carDTO.TransmissionType;
            }

            return await _carRepository.UpdateAsync(car);
        }



        public async Task<Car> DeleteCarAsync(Guid id)
        {
            return await _carRepository.DeleteByIdAsync(id);
        }
    }
}