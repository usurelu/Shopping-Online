using Shopping_Online.Repository.UnitOfWork;
using Shopping_Online.Services.Order;
using Shopping_Online.Services.Product;
using Shopping_Online.Services.User;

namespace Shopping_Online.Services
{
    public class ServiceFactory
    {
        public IOrderService OrderService { get; }
        public IProductService ProductService { get; }
        public IUserService UserService { get; }

        public ServiceFactory()
        {
            IUnitOfWork unitOfWork = new FileUnitOfWork();

            this.OrderService = new OrderService(unitOfWork);
            this.ProductService = new ProductService(unitOfWork);
            this.UserService = new UserService(unitOfWork);
        }
    }
}