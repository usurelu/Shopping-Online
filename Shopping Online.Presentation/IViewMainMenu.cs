namespace Shopping_Online.Presentation
{
    public interface IViewMainMenu
    {
        void ShowMenu();
        void SetController(IControllerMainMenu controllerMainMenu);
        void Display(string message);

        void AddUser();
        void DeleteUser();
        void AddProduct();
        void DeleteProduct();
        void AddOrder();
        void ShowOrdersByType();
    }
}