using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CarDealership.Model.Entities;
using CarDealership.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarDealership.Repositories.Implementations
{
    public class AdRepository : IAdRepository
    {
        private readonly DbContext _dbContext;

        public AdRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}