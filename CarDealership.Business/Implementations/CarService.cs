using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Common.Enums;
using CarDealership.Model.Entities;
using CarDealership.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;

namespace CarDealership.Business.Implementations
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IMapper _mapper;

        public CarService(IRepository<Car> carRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _mapper = mapper;
        }

        public Task<Car> GetCarByIdAsync(int id)
        {
            return _carRepository.GetByIdAsync(id);
        }

        public async Task<Car> AddCarAsync(CarDTO carDto)
        {
            var newCar = _mapper.Map<Car>(carDto);

            return await _carRepository.AddAsync(newCar);
        }

        public async Task<Car> UpdateCarAsync(CarDTO carDto)
        {
            var car = _carRepository.GetByIdAsync(carDto.Id).Result;

            car.Brand = carDto.Brand ?? car.Brand;
            car.Model = carDto.Model ?? car.Model;

            car.Power = carDto.Power == 0 ? car.Power : carDto.Power;
            car.Seats = carDto.Seats == 0 ? car.Seats : carDto.Seats;
            car.Doors = carDto.Doors == 0 ? car.Doors : carDto.Doors;
            car.EngineVolume = carDto.EngineVolume == 0 ? car.EngineVolume : carDto.EngineVolume;
            car.Kilometers = carDto.Kilometers == 0 ? car.Kilometers : carDto.Kilometers;

            car.ProductionYear = carDto.ProductionYear == 0 ? car.ProductionYear : carDto.ProductionYear;

            if (carDto.TransmissionType != TransmissionType.NOT_SET)
            {
                car.TransmissionType = carDto.TransmissionType;
            }

            return await _carRepository.UpdateAsync(car);
        }



        public async Task<Car> DeleteCarAsync(int id)
        {
            return await _carRepository.DeleteByIdAsync(id);
        }
    }
}