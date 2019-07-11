using System;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Shopping_Online.Entities;
using Shopping_Online.Repository.UnitOfWork;
using Shopping_Online.Validations;

namespace Shopping_Online.Services.User
{
    public class UserService : IUserService
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IUnitOfWork unitOfWork;
        private readonly UserValidation userValidaton;

        public UserService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            this.unitOfWork = unitOfWork;
            this.userValidaton = new UserValidation();
        }

        public void Add(string username, string password, int userCategoryID)
        {
            Logger.Info($"Adauga user: {username} {password} {userCategoryID}");

            Entities.User user = new Entities.User(username, password, (UserCategory)userCategoryID);

            this.userValidaton.Validate(user);

            this.unitOfWork.UsersRepository().Add(user);
        }

        public void Delete(int ID)
        {
            Logger.Info($"Sterge user cu id-ul: {ID}");

            Task<Entities.User> userTask = new Task<Entities.User>(() => this.unitOfWork.UsersRepository().GetEntityByID(ID));

            this.unitOfWork.UsersRepository().Delete(userTask.Result);
        }
    }
}