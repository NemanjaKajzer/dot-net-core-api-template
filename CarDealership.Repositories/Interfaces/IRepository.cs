using System;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealership.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> GetById(Guid id);

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);

        Task<TEntity> DeleteById(Guid id);
    }
}