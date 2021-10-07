using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using System;
using System.Threading.Tasks;

namespace CarDealership.Business.Interfaces
{
    public interface ICarService
    {
        Task<Car> GetCarByIdAsync(Guid id);

        Task<Car> AddCarAsync(CarDTO carDTO);

        Task<Car> UpdateCarAsync(CarDTO carDTO);

        Task<Car> DeleteCarAsync(Guid id);
    }
}