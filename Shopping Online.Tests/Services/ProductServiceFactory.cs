using Shopping_Online.Repository;
using Shopping_Online.Repository.UnitOfWork;
using Shopping_Online.Services;
using Shopping_Online.Services.Product;

namespace Shopping_Online.Tests.Services
{
    public class ProductServiceFactory
    {
        public static ProductService GetProductService(IUnitOfWork inMemoryUnitOfWork)
        {
            return new ProductService(inMemoryUnitOfWork);
        }
    }
}