using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using CarDealership.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
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

        public async Task<Car> UpdateCarAsync(Guid id, JsonPatchDocument<Car> patchDoc)
        {
            var car = _carRepository.GetByIdAsync(id).Result;
            patchDoc.ApplyTo(car);

            await _carRepository.UpdateAsync(car);

            return car;
        }



        public async Task<Car> DeleteCarAsync(Guid id)
        {
            return await _carRepository.DeleteByIdAsync(id);
        }
    }
}