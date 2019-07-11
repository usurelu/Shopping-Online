using Shopping_Online.Entities;
using Shopping_Online.Repository.InMemory;

namespace Shopping_Online.Repository.UnitOfWork
{
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        private IRepository<Order> orderRepository;
        private IRepository<Product> productRepository;
        private IRepository<User> userRepository;

        IRepository < Order > IUnitOfWork.OrdersRepository()
        {
            return this.orderRepository ?? (this.orderRepository = new InMemoryRepository<Order>());
        }

        IRepository<Product> IUnitOfWork.ProductsRepository()
        {
            return this.productRepository ?? (this.productRepository = new InMemoryRepository<Product>());
        }

        IRepository<User> IUnitOfWork.UsersRepository()
        {
            return this.userRepository ?? (this.userRepository = new InMemoryRepository<User>());
        }
    }
}