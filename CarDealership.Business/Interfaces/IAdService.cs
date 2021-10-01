using CarDealership.Model.Entities;
using Common.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Business.Interfaces
{
    public interface IAdService
    {
        IEnumerable<Ad> GetAll();
        Task<AdDTO> GetById(Guid id, Guid discountId);
    }
}