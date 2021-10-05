using System;
using System.Threading.Tasks;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using CarDealership.Repositories.Interfaces;
using Microsoft.AspNetCore.JsonPatch;

namespace CarDealership.Business.Interfaces
{
    public interface ISellerService
    {
        Task<Seller> GetSellerByIdAsync(Guid id);

        Task<Seller> AddSellerAsync(SellerDTO sellerDTO);

        //Task<Seller> UpdateSellerAsync(Guid id, JsonPatchDocument<Seller> patchDoc);

        Task<Seller> UpdateSellerAsync(SellerDTO sellerDTO);

        Task<Seller> DeleteSellerAsync(Guid id);
    }
}