using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using System;
using System.Threading.Tasks;

namespace CarDealership.Business.Interfaces
{
    public interface IAdService
    {
        Task<Ad> GetAdByIdAsync(int id, string promoCode);

        Task<Ad> AddAdAsync(AdCreationDTO adCreationDTO);

        Task<Ad> UpdateAdAsync(AdCreationDTO adCreationDTO);

        Task<Ad> DeleteAdAsync(int id);
    }
}