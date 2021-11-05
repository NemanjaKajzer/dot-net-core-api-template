using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CarDealership.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        Task<TEntity> GetByIdAsync(int id);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteByIdAsync(int id);

        Task<IEnumerable<TEntity>> FilterAsync(Expression<Func<TEntity, bool>> predicateExpression);

        Task<List<TEntity>> FilterNestedAsync(Expression<Func<TEntity, bool>> predicate,
            params Expression<Func<TEntity, object>>[] includes);
    }
}