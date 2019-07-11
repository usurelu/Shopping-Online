using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping_Online.Entities;
using Shopping_Online.Repository;
using Shopping_Online.Repository.UnitOfWork;
using Shopping_Online.Services;
using Shopping_Online.Services.User;
using Shopping_Online.Tests.Repository;
using Shopping_Online.Tests.Users;

namespace Shopping_Online.Tests.Services
{
    [TestClass]
    public class UserServiceTests
    {
        [TestMethod]
        public void CreateNew_AddFreeUser_WithSuccess()
        {
            IUnitOfWork inMemoryUnitOfWork = RepositoryFactory.GetUnitOfWork();
            IUserService userService = UserServiceFactory.GetUserService(inMemoryUnitOfWork);

            AddUserToService(userService, 1);

            Assert.AreEqual(1, inMemoryUnitOfWork.UsersRepository().GetCount());

            User savedUser = inMemoryUnitOfWork.UsersRepository().GetEntityByID(0);
            Assert.AreEqual(UsersFactory.FREE_USER, savedUser.Category);

            CheckUsernameAndPasword(savedUser);
        }

        [TestMethod]
        public void CreateNew_AddPremiumUser_WithSuccess()
        {
            IUnitOfWork inMemoryUnitOfWork = RepositoryFactory.GetUnitOfWork();
            IUserService userService = UserServiceFactory.GetUserService(inMemoryUnitOfWork);

            AddUserToService(userService, 2);

            User savedUser = inMemoryUnitOfWork.UsersRepository().GetEntityByID(0);

            Assert.AreEqual(1, inMemoryUnitOfWork.UsersRepository().GetCount());
            Assert.AreEqual(UsersFactory.PREMIUM_USER, savedUser.Category);

            CheckUsernameAndPasword(savedUser);
        }

        private static void CheckUsernameAndPasword(User savedUser)
        {
            Assert.AreEqual(UsersFactory.USERNAME, savedUser.Username);
            Assert.AreEqual(UsersFactory.PASSWORD, savedUser.Password);
        }

        [TestMethod]
        public void CreateNew_AddAndDeleteUser_WithSuccess()
        {
            IUnitOfWork inMemoryUnitOfWork = RepositoryFactory.GetUnitOfWork();
            IUserService userService = UserServiceFactory.GetUserService(inMemoryUnitOfWork);

            AddUserToService(userService, 1);
            userService.Delete(0);

            Assert.AreEqual(0, inMemoryUnitOfWork.UsersRepository().GetCount());
        }

        private static void AddUserToService(IUserService userService, int userCategoryID)
        {
            userService.Add(UsersFactory.USERNAME, UsersFactory.PASSWORD, userCategoryID);
        }
    }
}