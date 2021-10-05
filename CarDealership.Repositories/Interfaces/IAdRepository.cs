using System;
using System.Threading.Tasks;
using CarDealership.Model.Entities;

namespace CarDealership.Repositories.Interfaces
{
    public interface IAdRepository
    {
        Task<Ad> GetAdByIdNestedAsync(Guid id);
    }
}