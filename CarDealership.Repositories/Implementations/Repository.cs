using CarDealership.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarDealership.Repositories.Implementations
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
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

        public async Task<TEntity> DeleteByIdAsync(Guid id)
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

        public async Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicateExpression)
        {
            return await _dbContext.Set<TEntity>().Where(predicateExpression).ToListAsync();
        }

        //public async Task<IQueryable<TEntity>> FilterAsync2(Expression<Func<TEntity, bool>> predicateExpression, params Expression<Func<TEntity, object>>[] includes)
        //{
        //    if (includes != null)
        //    {
        //        predicateExpression = includes.Aggregate(predicateExpression,
        //            (current, include) => current.Include(include));
        //    }

        //    return  _dbContext.Set<TEntity>().Where(predicateExpression).Include(includes);
        //}


    }
}