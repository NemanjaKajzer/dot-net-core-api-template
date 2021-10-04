using CarDealership.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CarDealership.Common.DTOs;

namespace CarDealership.Business.Interfaces
{
    public interface IAdService
    {
        Task<AdDTO> GetById(Guid id, Guid discountId);
    }
}