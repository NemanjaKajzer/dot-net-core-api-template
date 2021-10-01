using CarDealership.Model.Entities;
using System;
using System.Threading.Tasks;

namespace CarDealership.Business.Interfaces
{
    public interface IDiscountService
    {
        Task<Discount> GetById(Guid id);
    }
}