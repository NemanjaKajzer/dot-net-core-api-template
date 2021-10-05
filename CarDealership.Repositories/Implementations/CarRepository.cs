using System;
using System.Linq;
using System.Threading.Tasks;
using CarDealership.Model.Entities;
using CarDealership.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Repositories.Implementations
{
    public class CarRepository : ICarRepository
    {
        private readonly DbContext _dbContext;

        public CarRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

    }
}