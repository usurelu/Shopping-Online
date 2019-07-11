using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shopping_Online.Entities;

namespace Shopping_Online.Tests.Users
{
    [TestClass]
    public class UsersTests
    {
        [TestMethod]
        public void CreateNew_CheckParameters_WithSuccess()
        {
            User user = UsersFactory.GetFreeUser();

            Assert.AreEqual(UsersFactory.USERNAME, user.Username);
            Assert.AreEqual(UsersFactory.PASSWORD, user.Password);
            Assert.AreEqual(UsersFactory.FREE_USER, user.Category);

            user.Category = UserCategory.PremiumUser;
            Assert.AreEqual(UsersFactory.PREMIUM_USER, user.Category);
        }
    }
}