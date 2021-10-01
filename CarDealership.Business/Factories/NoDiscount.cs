namespace CarDealership.Business.Factories
{
    public class NoDiscount : IDiscount
    {
        public int Apply(int price)
        {
            return price;
        }
    }
}