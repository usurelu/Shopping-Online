using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping_Online.Entities;

namespace Shopping_Online.Tests.Products
{
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void CreateNew_CheckParameters_WithSuccess()
        {
            Product product = ProductFactory.GetProduct();

            Assert.AreEqual(ProductFactory.NAME, product.Name);
            Assert.AreEqual(ProductFactory.PRICE, product.Price);
        }
    }
}
