using Shopping_Online.Entities;
using Shopping_Online.ValidationsExceptions;

namespace Shopping_Online.Validations
{
    public class OrderValidation
    {
        public void Validate(Order order)
        {
            if (order.User == null)
                throw new OrderValidationException("An order must contain a user!");

            if (order.Product == null)
                throw new OrderValidationException("An order must contain a product!");

            if (order.Quantity == default(int))
                throw new OrderValidationException("An order must have a quantity!");
        }
    }
}