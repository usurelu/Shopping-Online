namespace Shopping_Online.Services.User
{
    public interface IUserService
    {
        void Add(string username, string password, int userCategoryID);
        void Delete(int ID);
    }
}