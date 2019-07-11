using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Shopping_Online.Contracts.TransferObjects;
using Shopping_Online.Entities;
using Shopping_Online.Repository.UnitOfWork;
using Shopping_Online.Validations;

namespace Shopping_Online.Services.Order
{
    public class OrderService : IOrderService
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            this.unitOfWork = unitOfWork;
        }

        public void Add(int userID, int productID, int orderQuantity, int orderShippingTypeID)
        {
            Logger.Info($"Adauga comanda : {userID} {productID} {orderQuantity} {orderShippingTypeID}");

            Task<Entities.User> userTask = new Task<Entities.User>(() => GetUserByID(userID)); userTask.Start(); 
            Task<Entities.Product> productTask = new Task<Entities.Product>(() => GetProductByID(productID)); productTask.Start();

            Entities.Order order = new Entities.Order(userTask.Result, productTask.Result, orderQuantity, (OrderShippingType)orderShippingTypeID);

            OrderValidation orderValidation = new OrderValidation();
            orderValidation.Validate(order);

            this.unitOfWork.OrdersRepository().Add(order);
        }

        private Entities.Product GetProductByID(int productID)
        {
            return this.unitOfWork.ProductsRepository().GetEntityByID(productID);
        }

        private Entities.User GetUserByID(int userID)
        {
            return this.unitOfWork.UsersRepository().GetEntityByID(userID);
        }

        public List<OrderTransferObject> GetOrdersByType(int shippingTypeID)
        {
            Logger.Info($"Returnez comenzile de tipul : {shippingTypeID}");

            OrderShippingType orderShippingType = (OrderShippingType) shippingTypeID;
            List<Entities.Order> orders = this.unitOfWork.OrdersRepository().GetAll();

            return orders
                .Where(o => o.ShippingType == orderShippingType)
                .ToList()
                .ConvertToTransferObject();
        }
    }

    internal static class OrderServiceExtensionsMethods
    {
        public static List<OrderTransferObject> ConvertToTransferObject(this List<Entities.Order> orders)
        {
            return orders.Select(s => s.ConvertToTransferObject()).ToList();
        } 

        public static OrderTransferObject ConvertToTransferObject(this Entities.Order order)
        {
            OrderTransferObject orderTransferObject = new OrderTransferObject();
            orderTransferObject.ShippingType = order.ShippingType.ToString();
            orderTransferObject.ProductName = order.Product.Name;
            orderTransferObject.Quantity = order.Quantity;
            orderTransferObject.UserName = order.User.Username;

            return orderTransferObject;
        }
    }
}