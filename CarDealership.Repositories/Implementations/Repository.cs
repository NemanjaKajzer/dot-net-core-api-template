using CarDealership.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly ApplicationContext _dbContext;

        public Repository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _dbContext.Set<TEntity>();
        }

        public async Task<TEntity> GetById(Guid id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<TEntity> DeleteById(Guid id)
        {
            var entity = await _dbContext.Set<TEntity>().FindAsync(id);

            if (entity == null)
            {
                return entity;
            }


            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }
    }
}