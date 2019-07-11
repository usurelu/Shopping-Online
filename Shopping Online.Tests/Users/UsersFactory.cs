using Shopping_Online.Entities;

namespace Shopping_Online.Tests.Users
{
    public class UsersFactory
    {
        public const string USERNAME = "Username";

        public const string PASSWORD = "Password";

        public const UserCategory PREMIUM_USER = UserCategory.PremiumUser;

        public const UserCategory FREE_USER = UserCategory.FreeUser;

        public static User GetFreeUser()
        {
            return new User(USERNAME, PASSWORD, FREE_USER);
        }
    }
}