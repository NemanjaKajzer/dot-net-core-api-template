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
        private readonly IRepository<Seller> _sellerRepository;
        private readonly IAdRepository _customAdRepository;
        public AdService(IRepository<Ad> adRepository, IRepository<Discount> discountRepository, IRepository<Car> carRepository, IRepository<Seller> sellerRepository, IAdRepository customAdRepository)
        {
            _adRepository = adRepository;
            _discountRepository = discountRepository;
            _carRepository = carRepository;
            _sellerRepository = sellerRepository;
            _customAdRepository = customAdRepository;
        }

        public async Task<AdPresentationDTO> GetAdByIdAsync(Guid id, string? promoCode)
        {
            //var ad = await _adRepository.GetByIdAsync(id);
            var ad = _customAdRepository.GetAdByIdNestedAsync(id).Result;
            var car = await _carRepository.GetByIdAsync(ad.Car.Id);

            promoCode ??= "";

            var discountObject = _discountRepository.FilterAsync(x => x.PromoCode.Equals(promoCode)).Result.FirstOrDefault();

            var discount = DiscountFactory.Create(discountObject);

            var adDTO = new AdPresentationDTO()
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

        public async Task<Ad> AddAdAsync(AdCreationDTO adCreationDTO)
        {
            var ad = new Ad(adCreationDTO);
            ad = await _adRepository.AddAsync(ad);

            // add ad to seller's ads (this will write SellerId into Ad row)
            var seller = _sellerRepository.GetByIdAsync(adCreationDTO.SellerId).Result;
            seller.Ads ??= new List<Ad>() { ad };
            await _sellerRepository.UpdateAsync(seller);

            // assign Car to Ad
            var car = _carRepository.GetByIdAsync(adCreationDTO.CarId).Result;
            ad.Car = car;
            return await _adRepository.UpdateAsync(ad);

        }

        public async Task<Ad> UpdateAdAsync(AdCreationDTO adDTO)
        {
            var ad = _adRepository.GetByIdAsync(adDTO.Id).Result;

            ad.Price = adDTO.Price == 0 ? ad.Price : adDTO.Price;
            ad.Description = adDTO.Description ?? ad.Description;

            return await _adRepository.UpdateAsync(ad);
        }

        public async Task<Ad> DeleteAdAsync(Guid id)
        {
            return await _adRepository.DeleteByIdAsync(id);
        }
    }
}