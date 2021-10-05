using CarDealership.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealership.Common.DTOs;

namespace CarDealership.Business.Interfaces
{
    public interface IAdService
    {
        Task<AdPresentationDTO> GetAdByIdAsync(Guid id, string promoCode);

        Task<Ad> AddAdAsync(AdCreationDTO adDTO);

        //Task<AdDTO> UpdateAdAsync(Guid id, JsonPatchDocument<Car> patchDoc);

        Task<Ad> DeleteAdAsync(Guid id);
    }
}