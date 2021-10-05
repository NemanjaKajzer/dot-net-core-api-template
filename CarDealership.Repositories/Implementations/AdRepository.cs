using System;
using System.Linq;
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

        public async Task<Ad> GetAdByIdNestedAsync(Guid id)
        {
            return await _dbContext.Set<Ad>().Where(a => a.Id.Equals(id)).Include(a => a.Car).FirstOrDefaultAsync();
        }
    }
}