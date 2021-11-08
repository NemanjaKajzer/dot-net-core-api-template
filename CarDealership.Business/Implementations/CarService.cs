using AutoMapper;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Common.Enums;
using CarDealership.Model.Entities;
using CarDealership.Repositories.Interfaces;
using System.Threading.Tasks;

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

        public async Task<Car> AddCarAsync(CarDTO carDTO)
        {
            var newCar = _mapper.Map<Car>(carDTO);

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



        public async Task<Car> DeleteCarAsync(int id)
        {
            return await _carRepository.DeleteByIdAsync(id);
        }
    }
}