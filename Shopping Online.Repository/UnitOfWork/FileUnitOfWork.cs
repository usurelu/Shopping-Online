using Shopping_Online.Entities;
using Shopping_Online.Repository.File;

namespace Shopping_Online.Repository.UnitOfWork
{
    public class FileUnitOfWork : IUnitOfWork
    {
        private readonly IRepository<Order> orderRepository;
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<User> userRepository;

        public FileUnitOfWork()
        {
            this.orderRepository = new FileRepository<Order>("order.txt");
            this.productRepository = new FileRepository<Product>("product.txt");
            this.userRepository = new FileRepository<User>("user.txt");
        }

        IRepository<Order> IUnitOfWork.OrdersRepository()
        {
            return this.orderRepository;
        }

        IRepository<Product> IUnitOfWork.ProductsRepository()
        {
            return this.productRepository;
        }

        IRepository<User> IUnitOfWork.UsersRepository()
        {
            return this.userRepository;
        }
    }
}