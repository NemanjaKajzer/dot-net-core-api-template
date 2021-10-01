using CarDealership.Common.Enums;
using CarDealership.Model.Entities;

namespace CarDealership.Business.Factories
{
    public static class DiscountFactory
    {
        public static IDiscount Create(Discount? discount)
        {
            if(discount == null) return new NoDiscount();

            switch (discount.Type)
            {
                case DiscountTypes.NEW_CUSTOMER:
                    return new NewCustomerDiscount(discount);
                case DiscountTypes.RETURNING_CUSTOMER:
                    return new ReturningCustomerDiscount(discount);
                case DiscountTypes.BLACK_FRIDAY:
                    return new BlackFridayDiscount(discount);
                case DiscountTypes.NO_DISCOUNT:
                    return new NoDiscount();
                default:
                    return new NoDiscount();

            }
        }
    }
}