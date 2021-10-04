namespace CarDealership.Business.Factories.Discount
{
    internal class NewCustomerDiscount : IDiscount
    {
        private readonly Model.Entities.Discount _discount;

        public NewCustomerDiscount(Model.Entities.Discount discount)
        {
            _discount = discount;
        }

        public int Apply(int price)
        {
            return price - _discount.Value;
        }
    }
}