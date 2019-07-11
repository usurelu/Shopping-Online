using Shopping_Online.Entities;
using Shopping_Online.Tests.Products;
using Shopping_Online.Tests.Users;

namespace Shopping_Online.Tests.Orders
{
    public class OrderFactory
    {
        public const int QUANTITY = 10;

        public const OrderShippingType FREE_SHIPPING = OrderShippingType.FreeShipping;
        public const OrderShippingType PAID_SHIPPING = OrderShippingType.PaidShipping;

        public static Order GetFreeShippingOrder()
        {
            User user = UsersFactory.GetFreeUser();
            Product product = ProductFactory.GetProduct();
            Order order = new Order(user, product, QUANTITY, FREE_SHIPPING);

            return order;
        }
    }
}