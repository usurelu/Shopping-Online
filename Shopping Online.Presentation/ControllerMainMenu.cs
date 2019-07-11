using System;
using System.Collections.Generic;
using System.Reflection;
using log4net;
using Shopping_Online.Contracts.TransferObjects;
using Shopping_Online.Services;

namespace Shopping_Online.Presentation
{
    public class ControllerMainMenu : IControllerMainMenu
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IViewMainMenu viewMainMenu;
        private readonly ServiceFactory serviceFactory;

        private Dictionary<string, Action> mainMenu;

        public ControllerMainMenu(IViewMainMenu viewMainMenu, ServiceFactory serviceFactory)
        {
            if (viewMainMenu == null)
                throw new ArgumentNullException(nameof(viewMainMenu));
            if (serviceFactory == null)
                throw new ArgumentNullException(nameof(serviceFactory));

            this.viewMainMenu = viewMainMenu;
            this.serviceFactory = serviceFactory;
            this.viewMainMenu.SetController(this);
            PopulateMainMenu();
        }

        private void PopulateMainMenu()
        {
            Logger.Info("Populating Mainmenu");

            this.mainMenu = new Dictionary<string, Action>
            {
                ["1"] = () => this.viewMainMenu.AddUser(),
                ["2"] = () => this.viewMainMenu.DeleteUser(),
                ["3"] = () => this.viewMainMenu.AddProduct(),
                ["4"] = () => this.viewMainMenu.DeleteProduct(),
                ["5"] = () => this.viewMainMenu.AddOrder(),
                ["6"] = () => this.viewMainMenu.ShowOrdersByType()
            };

            this.viewMainMenu.ShowMenu();
        }

        public void BeginSession()
        {
            Logger.Info("Starting a new session");

            this.viewMainMenu.ShowMenu();
        }

        public void SetOption(string option)
        {
            try
            {
                Logger.Info($"Setting option: {option}");

                if (string.IsNullOrWhiteSpace(option) || option == string.Empty || !this.mainMenu.ContainsKey(option))
                    this.viewMainMenu.ShowMenu();
                else
                    this.mainMenu[option]();

                this.viewMainMenu.ShowMenu();
            }
            catch (Exception exception)
            {
                Logger.Error("Eroare la setarea optiunii",exception);
                this.viewMainMenu.Display(exception.Message);
            }
        }

        public void AddUser(string username, string password, string userCategory)
        {
            try
            {
                Logger.Info($"Adauga user: {username} {password} {userCategory}");
                int userCatgoryID = int.Parse(userCategory);

                this.serviceFactory.UserService.Add(username, password, userCatgoryID);
            }
            catch (Exception exception)
            {
                Logger.Error("Eroare la adaugarea userului", exception);
                this.viewMainMenu.Display(exception.Message);
            }
        }

        public void DeleteUser(string ID)
        {
            try
            {
                Logger.Info($"Sterge user cu id-ul: {ID}");
                int id = int.Parse(ID);

                this.serviceFactory.UserService.Delete(id);
            }
            catch (Exception exception)
            {
                Logger.Error("Eroare la stergerea userului", exception);
                this.viewMainMenu.Display(exception.Message);
            }
        }

        public void AddProduct(string name, string price)
        {
            try
            {
                Logger.Info($"Adauga produs : {name} {price}");
                decimal priceValue = decimal.Parse(price);

                this.serviceFactory.ProductService.Add(name, priceValue);
            }
            catch (Exception exception)
            {
                Logger.Error("Eroare la adaugarea produsului", exception);
                this.viewMainMenu.Display(exception.Message);
            }
        }

        public void DeleteProduct(string ID)
        {
            try
            {
                Logger.Info($"Sterge produsul cu id-ul: {ID}");
                int id = int.Parse(ID);

                this.serviceFactory.ProductService.Delete(id);
            }
            catch (Exception exception)
            {
                Logger.Error("Eroare la stergerea produsului", exception);
                this.viewMainMenu.Display(exception.Message);
            }
        }

        public void AddOrder(string userID, string productID, string quantity, string shippingType)
        {
            try
            {
                Logger.Info($"Adauga comanda : {userID} {productID} {quantity} {shippingType}");

                int userId = int.Parse(userID);
                int productId = int.Parse(productID);
                int quantityValue = int.Parse(quantity);
                int shippingTypeID = int.Parse(shippingType);

                this.serviceFactory.OrderService.Add(userId, productId, quantityValue, shippingTypeID);
            }
            catch (Exception exception)
            {
                Logger.Error("Eroare la adaugarea comenzii", exception);
                this.viewMainMenu.Display(exception.Message);
            }
        }

        public void ShowOrdersByType(string shippingType)
        {
            try
            {
                Logger.Info($"Afisez comenzile de tipul : {shippingType}");

                int shippingTypeID = int.Parse(shippingType);
                List<OrderTransferObject> orders = this.serviceFactory.OrderService.GetOrdersByType(shippingTypeID);

                foreach (OrderTransferObject order in orders)
                    this.viewMainMenu.Display(order.ToString());
            }
            catch (Exception exception)
            {
                Logger.Error("Eroare la afisarea comenzilor", exception);
                this.viewMainMenu.Display(exception.Message);
            }
        }
    }
}