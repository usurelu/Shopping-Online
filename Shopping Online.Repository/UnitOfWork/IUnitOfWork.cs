using Shopping_Online.Entities;

namespace Shopping_Online.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<Order> OrdersRepository();
        IRepository<Product> ProductsRepository();
        IRepository<User> UsersRepository();
    }
}