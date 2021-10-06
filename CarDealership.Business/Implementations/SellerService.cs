using System;
using System.Threading.Tasks;
using CarDealership.Business.Interfaces;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using CarDealership.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace CarDealership.Business.Implementations
{
    public class SellerService : ISellerService
    {
        private readonly IRepository<Seller> _sellerRepository;

        public SellerService(IRepository<Seller> sellerRepository)
        {
            _sellerRepository = sellerRepository;
        }

        public Task<Seller> GetSellerByIdAsync(Guid id)
        {
            return _sellerRepository.GetByIdAsync(id);
        }

        public async Task<Seller> AddSellerAsync(SellerDTO sellerDTO)
        {
            var newSeller = new Seller(sellerDTO);

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

        public async Task<Seller> DeleteSellerAsync(Guid id)
        {
            return await _sellerRepository.DeleteByIdAsync(id);
        }
    }
}