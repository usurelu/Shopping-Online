using System.Collections.Generic;
using Shopping_Online.Contracts.TransferObjects;

namespace Shopping_Online.Services.Order
{
    public interface IOrderService
    {
        void Add(int userID, int productID, int orderQuantity, int orderShippingTypeID);
        List<OrderTransferObject> GetOrdersByType(int shippingTypeID);
    }
}