namespace Shopping_Online.Services.Product
{
    public interface IProductService
    {
        void Add(string name, decimal price);
        void Delete(int ID);
    }
}