using CarDealership.Model.Entities;

namespace CarDealership.Business.Factories
{
    internal class ReturningCustomerDiscount : IDiscount
    {
        private readonly Discount _discount;

        public ReturningCustomerDiscount(Discount discount)
        {
            _discount = discount;
        }

        public int Apply(int price)
        {
            return price - price * _discount.Value / 100;
        }
    }
}