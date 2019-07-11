using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping_Online.Entities;
using Shopping_Online.Tests.Orders;
using Shopping_Online.Tests.Products;
using Shopping_Online.Tests.Users;
using Shopping_Online.Validations;
using Shopping_Online.ValidationsExceptions;

namespace Shopping_Online.Tests.Validations
{
    [TestClass]
    public class OrderValidationsTests
    {
        [TestMethod]
        public void CreateNew_ValidateOrder_WithSuccess()
        {
            OrderValidation orderValidation = ValidationsFactory.GetOrderValidation();
            Order order = OrderFactory.GetFreeShippingOrder();

            orderValidation.Validate(order);
        }

        [TestMethod]
        [ExpectedException(typeof(OrderValidationException))]
        public void CreateNew_ValidateOrder_WithNullUser()
        {
            OrderValidation orderValidation = ValidationsFactory.GetOrderValidation();
            Order order = new Order(null, ProductFactory.GetProduct(), ProductFactory.PRICE, OrderFactory.FREE_SHIPPING);

            orderValidation.Validate(order);
        }

        [TestMethod]
        [ExpectedException(typeof(OrderValidationException))]
        public void CreateNew_ValidateOrder_WithNullProduct()
        {
            OrderValidation orderValidation = ValidationsFactory.GetOrderValidation();
            Order order = new Order(UsersFactory.GetFreeUser(), null, ProductFactory.PRICE, OrderFactory.FREE_SHIPPING);

            orderValidation.Validate(order);
        }

        [TestMethod]
        [ExpectedException(typeof(OrderValidationException))]
        public void CreateNew_ValidateOrder_WithNoQuantity()
        {
            OrderValidation orderValidation = ValidationsFactory.GetOrderValidation();
            Order order = new Order(UsersFactory.GetFreeUser(), ProductFactory.GetProduct(), default(int), OrderFactory.FREE_SHIPPING);

            orderValidation.Validate(order);
        }
    }
}