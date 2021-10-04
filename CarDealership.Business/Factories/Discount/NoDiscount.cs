namespace CarDealership.Business.Factories.Discount
{
    public class NoDiscount : IDiscount
    {
        public int Apply(int price)
        {
            return price;
        }
    }
}