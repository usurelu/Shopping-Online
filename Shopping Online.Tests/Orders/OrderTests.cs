using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping_Online.Entities;
using Shopping_Online.Tests.Products;
using Shopping_Online.Tests.Users;

namespace Shopping_Online.Tests.Orders
{
    [TestClass]
    public class OrderTests
    {
        [TestMethod]
        public void CreateNew_CheckParameters_WithSuccess()
        {
            Order order = OrderFactory.GetFreeShippingOrder();

            Assert.AreEqual(UsersFactory.GetFreeUser(), order.User);
            Assert.AreEqual(ProductFactory.GetProduct(), order.Product);
            Assert.AreEqual(OrderFactory.QUANTITY, order.Quantity);
            Assert.AreEqual(OrderFactory.FREE_SHIPPING, order.ShippingType);

            order.ShippingType = OrderShippingType.PaidShipping;
            Assert.AreEqual(OrderFactory.PAID_SHIPPING, order.ShippingType);
        }
    }
}