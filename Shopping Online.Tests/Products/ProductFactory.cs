using Shopping_Online.Entities;

namespace Shopping_Online.Tests.Products
{
    public class ProductFactory
    {
        public const string NAME = "Name";

        public const int PRICE = 10;

        public static Product GetProduct()
        {
            return new Product(NAME, PRICE);
        }
    }
}