using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping_Online.Entities;
using Shopping_Online.Repository;
using Shopping_Online.Repository.UnitOfWork;
using Shopping_Online.Services;
using Shopping_Online.Services.Product;
using Shopping_Online.Tests.Products;
using Shopping_Online.Tests.Repository;

namespace Shopping_Online.Tests.Services
{
    [TestClass]
    public class ProductServiceTests
    {
        [TestMethod]
        public void CreateNew_AddProduct_WithSuccess()
        {
            IUnitOfWork inMemoryUnitOfWork = RepositoryFactory.GetUnitOfWork();
            IProductService productService = ProductServiceFactory.GetProductService(inMemoryUnitOfWork);

            AddProductToService(productService);

            Assert.AreEqual(1, inMemoryUnitOfWork.ProductsRepository().GetCount());

            Product savedProduct = inMemoryUnitOfWork.ProductsRepository().GetEntityByID(0);
            Assert.AreEqual(ProductFactory.NAME, savedProduct.Name);
            Assert.AreEqual(ProductFactory.PRICE, savedProduct.Price);
        }

        [TestMethod]
        public void CreateNew_AddProductDeletProduct_WithSuccess()
        {
            IUnitOfWork inMemoryUnitOfWork = RepositoryFactory.GetUnitOfWork();
            IProductService productService = ProductServiceFactory.GetProductService(inMemoryUnitOfWork);

            productService.Add(ProductFactory.NAME, ProductFactory.PRICE);
            productService.Delete(0);

            Assert.AreEqual(0, inMemoryUnitOfWork.ProductsRepository().GetCount());
        }

        private static void AddProductToService(IProductService productService)
        {
            productService.Add(ProductFactory.NAME, ProductFactory.PRICE);
        }
    }
}