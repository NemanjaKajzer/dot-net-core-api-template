using CarDealership.Model.Entities;

namespace CarDealership.Business.Factories
{
    internal class NewCustomerDiscount : IDiscount
    {
        private readonly Discount _discount;

        public NewCustomerDiscount(Discount discount)
        {
            _discount = discount;
        }

        public int Apply(int price)
        {
            return price - _discount.Value;
        }
    }
}