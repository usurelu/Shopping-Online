using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping_Online.Entities;
using Shopping_Online.Repository;
using Shopping_Online.Repository.UnitOfWork;

namespace Shopping_Online.Tests.Repository
{
    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void CreateNew_CheckSize_IsZero()
        {
            IRepository<Entity> repository = RepositoryFactory.GetRepository();

            Assert.AreEqual(0, repository.GetCount());
        }

        [TestMethod]
        public void CreateNew_AddEntity_CountIsOne()
        {
            IRepository<Entity> repository = RepositoryFactory.GetRepository();
            Entity entity = RepositoryFactory.GetEntity();

            repository.Add(entity);

            Assert.AreEqual(1, repository.GetCount());
        }

        [TestMethod]
        public void CreateNew_AddEntity_EntityHasID()
        {
            IRepository<Entity> repository = RepositoryFactory.GetRepository();
            Entity firstEntity = RepositoryFactory.GetEntity();
            Entity secondEntity = RepositoryFactory.GetEntity();

            repository.Add(firstEntity);
            repository.Add(secondEntity);

            Assert.AreEqual(secondEntity, repository.GetEntityByID(1));
        }

        [TestMethod]
        public void CreateNew_DeleteEntity_WithSuccess()
        {
            IRepository<Entity> repository = RepositoryFactory.GetRepository();
            Entity entity = RepositoryFactory.GetEntity();

            repository.Add(entity);
            repository.Delete(entity);

            Assert.AreEqual(0, repository.GetCount());
        }

        [TestMethod]
        public void CreateNew_GetEnumerator_WithSuccess()
        {
            IRepository<Entity> repository = RepositoryFactory.GetRepository();
            
            Assert.IsNotNull(repository.GetAll());
        }

        [TestMethod]
        public void CreateUnitOfWork_GetIRepository_WithSuccess()
        {
            IUnitOfWork inMemoryUnitOfWork = RepositoryFactory.GetUnitOfWork();

            Assert.IsNotNull(inMemoryUnitOfWork.OrdersRepository());
            Assert.IsNotNull(inMemoryUnitOfWork.ProductsRepository());
            Assert.IsNotNull(inMemoryUnitOfWork.UsersRepository());
        }
    }
}