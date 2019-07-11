using Shopping_Online.Entities;
using Shopping_Online.ValidationsExceptions;

namespace Shopping_Online.Validations
{
    public class UserValidation
    {
        public void Validate(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Username) || user.Username  == string.Empty)
                throw new UserValidationException("An user must have an username!");

            if (string.IsNullOrWhiteSpace(user.Password) || user.Password == string.Empty)
                throw new UserValidationException("An user must have an password!");
        }
    }
}