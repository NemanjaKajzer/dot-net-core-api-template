using System;
using CarDealership.Common.DTOs;
using CarDealership.Model.Entities;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarDealership.Business.Interfaces
{
    public interface ICarService
    {
        Task<Car> GetCarByIdAsync(Guid id);

        Task<Car> AddCarAsync(CarDTO carDto);

        Task<Car> UpdateCarAsync(Guid id, JsonPatchDocument<Car> patchDoc);

        Task<Car> DeleteCarAsync(Guid id);
    }
}