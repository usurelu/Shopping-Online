using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping_Online.Entities;
using Shopping_Online.Tests.Products;
using Shopping_Online.Validations;
using Shopping_Online.ValidationsExceptions;

namespace Shopping_Online.Tests.Validations
{
    [TestClass]
    public class ProductValidationsTests
    {
        [TestMethod]
        public void CreateNew_ValidateProduct_WithSuccess()
        {
            ProductValidation productValidation = ValidationsFactory.GetProductValidation();
            Product product = ProductFactory.GetProduct();

            productValidation.Validate(product);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductValidationException))]
        public void CreateNew_ValidateProduct_WithNullName()
        {
            ProductValidation productValidation = ValidationsFactory.GetProductValidation();
            Product product = new Product(null, 1);

            productValidation.Validate(product);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductValidationException))]
        public void CreateNew_ValidateProduct_WithEmptyName()
        {
            ProductValidation productValidation = ValidationsFactory.GetProductValidation();
            Product product = new Product(string.Empty, ProductFactory.PRICE);

            productValidation.Validate(product);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductValidationException))]
        public void CreateNew_ValidateProduct_WithWhitespaceName()
        {
            ProductValidation productValidation = ValidationsFactory.GetProductValidation();
            Product product = new Product(" ", ProductFactory.PRICE);

            productValidation.Validate(product);
        }

        [TestMethod]
        [ExpectedException(typeof(ProductValidationException))]
        public void CreateNew_ValidateProduct_WithNoPrice()
        {
            ProductValidation productValidation = ValidationsFactory.GetProductValidation();
            Product product = new Product(ProductFactory.NAME, 0);

            productValidation.Validate(product);
        }
    }
}