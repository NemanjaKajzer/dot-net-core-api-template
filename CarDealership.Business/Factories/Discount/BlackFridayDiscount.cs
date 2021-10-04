namespace CarDealership.Business.Factories.Discount
{
    internal class BlackFridayDiscount : IDiscount
    {
        private readonly Model.Entities.Discount _discount;

        public BlackFridayDiscount(Model.Entities.Discount discount)
        {
            _discount = discount;
        }

        public int Apply(int price)
        {
            return price - price * _discount.Value / 100;
        }
    }
}