using Shopping_Online.Entities;
using Shopping_Online.ValidationsExceptions;

namespace Shopping_Online.Validations
{
    public class ProductValidation
    {
        public void Validate(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name) || product.Name == string.Empty)
                throw new ProductValidationException("A product must have a name!");

            if (product.Price == default(decimal))
                throw new ProductValidationException("A product must have a price value!");
        }
    }
}