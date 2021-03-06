using AutoMapper;
using CarDealership.Business.Factories.Discount;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Common.Enums;
using CarDealership.Model.Entities;
using CarDealership.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Business.Implementations
{
    public class AdService : IAdService
    {
        private readonly IRepository<Ad> _adRepository;
        private readonly IRepository<Discount> _discountRepository;
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Seller> _sellerRepository;
        private readonly IMapper _mapper;

        public AdService(IRepository<Ad> adRepository, IRepository<Discount> discountRepository, IRepository<Car> carRepository, IRepository<Seller> sellerRepository, IMapper mapper)
        {
            _adRepository = adRepository;
            _discountRepository = discountRepository;
            _carRepository = carRepository;
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }

        public async Task<Ad> GetAdByIdAsync(int id, string? promoCode)
        {
            var result = await _adRepository.FilterNestedAsync(x => x.Id.Equals(id), c => c.Car, s => s.Seller);
            var ad = result.FirstOrDefault();

            if (ad == null) return new Ad();

            // if there is no promo code, no discount is applied
            promoCode ??= "";
            var discountObject = _discountRepository.FilterAsync(x => x.PromoCode.Equals(promoCode)).Result.FirstOrDefault();
            var discount = DiscountFactory.Create(discountObject);
            ad.Price = discount.Apply(ad.Price);

            return ad;
        }

        public async Task<Ad> AddAdAsync(AdCreationDTO adCreationDTO)
        {
            var ad = _mapper.Map<Ad>(adCreationDTO);
            var seller = _mapper.Map<int, Seller>(adCreationDTO.SellerId);
            var car = _mapper.Map<int, Car>(adCreationDTO.CarId);

            ad = await _adRepository.AddAsync(ad);

            // add ad to seller's ads (this will write SellerId into Ad row)
            //var seller = _sellerRepository.GetByIdAsync(adCreationDTO.SellerId).Result;
            seller.Ads ??= new List<Ad>() { ad };
            await _sellerRepository.UpdateAsync(seller);

            ad.Seller = seller;

            // assign Car to Ad
            ad.Car = car;
            return await _adRepository.UpdateAsync(ad);

        }

        public async Task<Ad> UpdateAdAsync(AdCreationDTO adDTO)
        {
            var ad = _adRepository.GetByIdAsync(adDTO.Id).Result;

            ad.Price = adDTO.Price == 0 ? ad.Price : adDTO.Price;
            ad.Description = adDTO.Description ?? ad.Description;

            if (adDTO.Currency != Currency.NOT_SET)
            {
                ad.Currency = adDTO.Currency;
            }


            if (adDTO.CarId != 0)
            {
                var car = await _carRepository.GetByIdAsync(adDTO.CarId);
                ad.Car = car;
            }

            return await _adRepository.UpdateAsync(ad);
        }

        public async Task<Ad> DeleteAdAsync(int id)
        {
            return await _adRepository.DeleteByIdAsync(id);
        }
    }
}