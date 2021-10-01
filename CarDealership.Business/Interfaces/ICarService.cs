using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Business.Interfaces
{
    public interface ICarService
    {
        IEnumerable<Car> GetAll();
        Task<Car> AddCar(CarDTO carDto);
    }
}