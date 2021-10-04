using CarDealership.Business.Factories;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using CarDealership.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.Business.Factories.Discount;

namespace CarDealership.Business.Implementations
{
    public class AdService : IAdService
    {
        private readonly IRepository<Ad> _adRepository;
        private readonly IRepository<Discount> _discountRepository;
        private readonly IRepository<Car> _carRepository;

        public AdService(IRepository<Ad> adRepository, IRepository<Discount> discountRepository, IRepository<Car> carRepository)
        {
            _adRepository = adRepository;
            _discountRepository = discountRepository;
            _carRepository = carRepository;
        }

        public async Task<AdDTO> GetById(Guid id, Guid discountId)
        {
            var ad = await _adRepository.GetByIdAsync(id);
            var car = await _carRepository.GetByIdAsync(ad.CarId);
            var discount = DiscountFactory.Create(await _discountRepository.GetByIdAsync(discountId));

            var adDTO = new AdDTO
            {
                Id = ad.Id,
                Currency = ad.Currency,
                Description = ad.Description,
                Price = discount.Apply(ad.Price),
                Car = new CarDTO
                {
                    Brand = car.Brand,
                    Model = car.Model,
                    Power = car.Power,
                    Seats = car.Seats,
                    Doors = car.Doors,
                    ProductionYear = car.ProductionYear,
                    EngineVolume = car.EngineVolume,
                    Kilometers = car.Kilometers,
                    TransmissionType = car.TransmissionType
                }
            };


            return adDTO;
        }
    }
}