using Shopping_Online.Entities;
using Shopping_Online.Repository;
using Shopping_Online.Repository.InMemory;
using Shopping_Online.Repository.UnitOfWork;

namespace Shopping_Online.Tests.Repository
{
    public class RepositoryFactory
    {
        public static InMemoryRepository<Entity> GetRepository()
        {
            return new InMemoryRepository<Entity>();
        }

        public static Entity GetEntity()
        {
            return new Entity();
        }

        public static IUnitOfWork GetUnitOfWork()
        {
            return new InMemoryUnitOfWork();
        }
    }
}