using Shopping_Online.Repository;
using Shopping_Online.Repository.UnitOfWork;
using Shopping_Online.Services;
using Shopping_Online.Services.Order;

namespace Shopping_Online.Tests.Services
{
    public class OrderServiceFactory
    {
        public static OrderService GetOrderService(IUnitOfWork inMemoryUnitOfWork)
        {
            return new OrderService(inMemoryUnitOfWork);
        }
    }
}