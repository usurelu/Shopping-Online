namespace Shopping_Online.Presentation
{
    public interface IControllerMainMenu
    {
        void BeginSession();
        void SetOption(string option);
        void AddUser(string username, string password, string userCategory);
        void DeleteUser(string ID);
        void AddProduct(string name, string price);
        void DeleteProduct(string ID);
        void AddOrder(string userID, string productID, string quantity, string shippingType);
        void ShowOrdersByType(string shippingType);
    }
}