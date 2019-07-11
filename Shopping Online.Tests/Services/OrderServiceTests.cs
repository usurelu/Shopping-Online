using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping_Online.Entities;
using Shopping_Online.Repository;
using Shopping_Online.Repository.UnitOfWork;
using Shopping_Online.Services;
using Shopping_Online.Services.Order;
using Shopping_Online.Tests.Orders;
using Shopping_Online.Tests.Products;
using Shopping_Online.Tests.Repository;
using Shopping_Online.Tests.Users;
using Shopping_Online.ValidationsExceptions;

namespace Shopping_Online.Tests.Services
{
    [TestClass]
    public class OrderServiceTests
    {
        [TestMethod]
        public void CreateNew_AddFreeOrder_WithSuccess()
        {
            IUnitOfWork inMemoryUnitOfWork = RepositoryFactory.GetUnitOfWork();
            IOrderService orderService = OrderServiceFactory.GetOrderService(inMemoryUnitOfWork);
            int userID = 0;
            int productID = 0;

            inMemoryUnitOfWork.UsersRepository().Add(UsersFactory.GetFreeUser());
            inMemoryUnitOfWork.ProductsRepository().Add(ProductFactory.GetProduct());

            orderService.Add(userID, productID, OrderFactory.QUANTITY, (int)OrderFactory.FREE_SHIPPING);

            Assert.AreEqual(1, inMemoryUnitOfWork.OrdersRepository().GetCount());

            Order savedOrder = inMemoryUnitOfWork.OrdersRepository().GetEntityByID(0);
            Assert.AreEqual(UsersFactory.GetFreeUser(), savedOrder.User);
            Assert.AreEqual(ProductFactory.GetProduct(), savedOrder.Product);
            Assert.AreEqual(OrderFactory.QUANTITY, savedOrder.Quantity);
        }

        [TestMethod]
        [ExpectedException(typeof(OrderValidationException))]
        public void CreateNew_AddFreeOrderWithNullUser_WithException()
        {
            IUnitOfWork inMemoryUnitOfWork = RepositoryFactory.GetUnitOfWork();
            IOrderService orderService = OrderServiceFactory.GetOrderService(inMemoryUnitOfWork);

            orderService.Add(0, 0, OrderFactory.QUANTITY, (int)OrderShippingType.FreeShipping);
        }

        [TestMethod]
        [ExpectedException(typeof(OrderValidationException))]
        public void CreateNew_AddFreeOrderWithNullProduct_WithException()
        {
            IUnitOfWork inMemoryUnitOfWork = RepositoryFactory.GetUnitOfWork();
            IOrderService orderService = OrderServiceFactory.GetOrderService(inMemoryUnitOfWork);

            inMemoryUnitOfWork.UsersRepository().Add(UsersFactory.GetFreeUser());
            orderService.Add(0, 0, OrderFactory.QUANTITY, (int)OrderShippingType.FreeShipping);
        }
    }
}