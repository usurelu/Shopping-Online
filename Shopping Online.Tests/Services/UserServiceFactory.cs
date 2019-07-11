using Shopping_Online.Repository;
using Shopping_Online.Repository.UnitOfWork;
using Shopping_Online.Services;
using Shopping_Online.Services.User;

namespace Shopping_Online.Tests.Services
{
    public class UserServiceFactory
    {
        public static UserService GetUserService(IUnitOfWork inMemoryUnitOfWork)
        {
            return new UserService(inMemoryUnitOfWork);
        }
    }
}