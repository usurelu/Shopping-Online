using Shopping_Online.Validations;

namespace Shopping_Online.Tests.Validations
{
    public class ValidationsFactory
    {
        public static OrderValidation GetOrderValidation()
        {
            return new OrderValidation();
        }

        public static UserValidation GetUserValidation()
        {
            return new UserValidation();
        }

        public static ProductValidation GetProductValidation()
        {
            return new ProductValidation();
        }
    }
}