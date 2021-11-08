using CarDealership.Model.Entities;
using System.Threading.Tasks;

namespace CarDealership.Business.Interfaces
{
    public interface IDiscountService
    {
        Task<Discount> GetByIdAsync(int id);
    }
}