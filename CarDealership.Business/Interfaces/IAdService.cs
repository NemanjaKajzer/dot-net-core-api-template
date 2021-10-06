using CarDealership.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealership.Common.DTOs;

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