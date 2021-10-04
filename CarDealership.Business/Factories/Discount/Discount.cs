using CarDealership.Common.Enums;

namespace CarDealership.Business.Factories.Discount
{
    public static class DiscountFactory
    {
        public static IDiscount Create(Model.Entities.Discount? discount)
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