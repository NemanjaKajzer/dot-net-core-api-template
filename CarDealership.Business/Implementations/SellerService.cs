using AutoMapper;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using CarDealership.Repositories.Interfaces;
using System.Threading.Tasks;

namespace CarDealership.Business.Implementations
{
    public class SellerService : ISellerService
    {
        private readonly IRepository<Seller> _sellerRepository;
        private readonly IMapper _mapper;

        public SellerService(IRepository<Seller> sellerRepository, IMapper mapper)
        {
            _sellerRepository = sellerRepository;
            _mapper = mapper;
        }

        public Task<Seller> GetSellerByIdAsync(int id)
        {
            return _sellerRepository.GetByIdAsync(id);
        }

        public async Task<Seller> AddSellerAsync(SellerDTO sellerDTO)
        {
            var newSeller = _mapper.Map<Seller>(sellerDTO);

            return await _sellerRepository.AddAsync(newSeller);
        }

        public async Task<Seller> UpdateSellerAsync(SellerDTO sellerDTO)
        {
            var seller = _sellerRepository.GetByIdAsync(sellerDTO.Id).Result;

            seller.Name = sellerDTO.Name ?? seller.Name;
            seller.Surname = sellerDTO.Surname ?? seller.Surname;
            seller.Email = sellerDTO.Email ?? seller.Email;

            return await _sellerRepository.UpdateAsync(seller);
        }

        public async Task<Seller> DeleteSellerAsync(int id)
        {
            return await _sellerRepository.DeleteByIdAsync(id);
        }
    }
}