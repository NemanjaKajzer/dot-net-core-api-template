namespace CarDealership.Business.Factories.Discount
{
    internal class ReturningCustomerDiscount : IDiscount
    {
        private readonly Model.Entities.Discount _discount;

        public ReturningCustomerDiscount(Model.Entities.Discount discount)
        {
            _discount = discount;
        }

        public int Apply(int price)
        {
            return price - price * _discount.Value / 100;
        }
    }
}