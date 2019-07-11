using System;
using System.Reflection;
using System.Threading.Tasks;
using log4net;
using Shopping_Online.Repository.UnitOfWork;
using Shopping_Online.Validations;

namespace Shopping_Online.Services.Product
{
    public class ProductService : IProductService
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        private readonly IUnitOfWork unitOfWork;
        private readonly ProductValidation productValidation;

        public ProductService(IUnitOfWork unitOfWork)
        {
            if (unitOfWork == null)
                throw new ArgumentNullException(nameof(unitOfWork));

            this.unitOfWork = unitOfWork;
            this.productValidation = new ProductValidation();
        }

        public void Add(string name, decimal price)
        {
            Logger.Info($"Adauga produs : {name} {price}");

            Entities.Product product = new Entities.Product(name, price);

            this.productValidation.Validate(product);

            this.unitOfWork.ProductsRepository().Add(product);
        }

        public void Delete(int ID)
        {
            Logger.Info($"Sterge produsul cu id-ul: {ID}");

            Task<Entities.Product> productTask = new Task<Entities.Product>(() => this.unitOfWork.ProductsRepository().GetEntityByID(ID));

            this.unitOfWork.ProductsRepository().Delete(productTask.Result);
        }
    }
}