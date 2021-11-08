using CarDealership.Business.Interfaces;
using CarDealership.Model.Entities;
using CarDealership.Repositories.Interfaces;
using System.Threading.Tasks;

namespace CarDealership.Business.Implementations
{
    public class DiscountService : IDiscountService
    {
        private readonly IRepository<Discount> _discountRepository;

        public DiscountService(IRepository<Discount> discountRepository)
        {
            _discountRepository = discountRepository;
        }

        public async Task<Discount> GetByIdAsync(int id)
        {
            return  await _discountRepository.GetByIdAsync(id);
        }
    }
}