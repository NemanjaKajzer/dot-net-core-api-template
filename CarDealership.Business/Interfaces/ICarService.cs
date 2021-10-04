using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Business.Interfaces
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> FilterCarsAsync();

        Task<Car> AddCarAsync(CarDTO carDto);
    }
}