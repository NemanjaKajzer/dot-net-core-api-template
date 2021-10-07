using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using System;
using System.Threading.Tasks;

namespace CarDealership.Business.Interfaces
{
    public interface IAdService
    {
        Task<Ad> GetAdByIdAsync(Guid id, string promoCode);

        Task<Ad> AddAdAsync(AdCreationDTO adCreationDTO);

        Task<Ad> UpdateAdAsync(AdCreationDTO adCreationDTO);

        Task<Ad> DeleteAdAsync(Guid id);
    }
}