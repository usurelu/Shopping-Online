using System;

namespace Shopping_Online.Presentation
{
    public class ViewMainMenu : IViewMainMenu
    {
        private IControllerMainMenu controllerMainMenu;

        public void SetController(IControllerMainMenu controllerMainMenu)
        {
            if (controllerMainMenu == null)
                throw new ArgumentNullException(nameof(controllerMainMenu));

            this.controllerMainMenu = controllerMainMenu;
        }

        public void Display(string message)
        {
            Console.WriteLine(message);
        }

        public void AddUser()
        {
            Console.Write("Username = ");
            string username = Console.ReadLine();

            Console.Write("Pasword = ");
            string password = Console.ReadLine();

            Console.WriteLine("1 = Free User, 2 = Paid User");
            string userCategory = Console.ReadLine();

            this.controllerMainMenu.AddUser(username, password, userCategory);
        }

        public void DeleteUser()
        {
            string ID = GetID();

            this.controllerMainMenu.DeleteUser(ID);
        }

        private static string GetID()
        {
            Console.Write("ID = ");
            return Console.ReadLine();
        }

        public void AddProduct()
        {
            Console.Write("Name = ");
            string name = Console.ReadLine();

            Console.Write("Price = ");
            string price = Console.ReadLine();

            this.controllerMainMenu.AddProduct(name, price);
        }

        public void DeleteProduct()
        {
            string ID = GetID();

            this.controllerMainMenu.DeleteProduct(ID);
        }

        public void AddOrder()
        {
            Console.Write("User ID = ");
            string userID = Console.ReadLine();

            Console.Write("Product ID = ");
            string productID = Console.ReadLine();

            Console.Write("Quantity = ");
            string quantity = Console.ReadLine();

            string shippingType = GetShippingType();

            this.controllerMainMenu.AddOrder(userID, productID, quantity, shippingType);
        }

        public void ShowOrdersByType()
        {
            string shippingType = GetShippingType();

            this.controllerMainMenu.ShowOrdersByType(shippingType);
        }

        private static string GetShippingType()
        {
            Console.WriteLine("1. Free shipping 2.Paid shipping");
            return Console.ReadLine();
        }

        public void ShowMenu()
        {
            Console.WriteLine("1. Add user");
            Console.WriteLine("2. Delete user");
            Console.WriteLine("3. Add product");
            Console.WriteLine("4. Add product");
            Console.WriteLine("5. Add order");
            Console.WriteLine("6. Show orders by type");
            Console.WriteLine();
            Console.Write("Selected option = ");

            string option = Console.ReadLine();

            this.controllerMainMenu.SetOption(option);
        }
    }
}