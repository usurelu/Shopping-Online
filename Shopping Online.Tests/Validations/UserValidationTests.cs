using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping_Online.Entities;
using Shopping_Online.Tests.Users;
using Shopping_Online.Validations;
using Shopping_Online.ValidationsExceptions;

namespace Shopping_Online.Tests.Validations
{
    [TestClass]
    public class UserValidationTests
    {
        [TestMethod]
        public void CreateNew_ValidateUser_WithSuccess()
        {
            UserValidation userValidation = ValidationsFactory.GetUserValidation();
            User user = UsersFactory.GetFreeUser();

            userValidation.Validate(user);
        }

        [TestMethod]
        [ExpectedException(typeof(UserValidationException))]
        public void CreateNew_ValidateUser_WithNullUsername()
        {
            UserValidation userValidation = ValidationsFactory.GetUserValidation();
            User user = new User(null, UsersFactory.PASSWORD, UsersFactory.FREE_USER);

            userValidation.Validate(user);
        }

        [TestMethod]
        [ExpectedException(typeof(UserValidationException))]
        public void CreateNew_ValidateUser_WithEmptyUsername()
        {
            UserValidation userValidation = ValidationsFactory.GetUserValidation();
            User user = new User(string.Empty, UsersFactory.PASSWORD, UsersFactory.FREE_USER);

            userValidation.Validate(user);
        }

        [TestMethod]
        [ExpectedException(typeof(UserValidationException))]
        public void CreateNew_ValidateUser_WithWhitespaceUsername()
        {
            UserValidation userValidation = ValidationsFactory.GetUserValidation();
            User user = new User("  ", UsersFactory.PASSWORD, UsersFactory.FREE_USER);

            userValidation.Validate(user);
        }

        [TestMethod]
        [ExpectedException(typeof(UserValidationException))]
        public void CreateNew_ValidateUser_WithNullPassword()
        {
            UserValidation userValidation = ValidationsFactory.GetUserValidation();
            User user = new User(UsersFactory.USERNAME, null, UsersFactory.FREE_USER);

            userValidation.Validate(user);
        }

        [TestMethod]
        [ExpectedException(typeof(UserValidationException))]
        public void CreateNew_ValidateUser_WithEmptyPassword()
        {
            UserValidation userValidation = ValidationsFactory.GetUserValidation();
            User user = new User(UsersFactory.USERNAME, string.Empty, UsersFactory.FREE_USER);

            userValidation.Validate(user);
        }

        [TestMethod]
        [ExpectedException(typeof(UserValidationException))]
        public void CreateNew_ValidateUser_WithWhitespacePassword()
        {
            UserValidation userValidation = ValidationsFactory.GetUserValidation();
            User user = new User(UsersFactory.USERNAME, " ", UsersFactory.FREE_USER);

            userValidation.Validate(user);
        }
    }
}