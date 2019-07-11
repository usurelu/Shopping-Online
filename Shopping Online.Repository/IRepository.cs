using System.Collections.Generic;

namespace Shopping_Online.Repository
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Delete(T entity);

        int GetCount();

        T GetEntityByID(int id);
        List<T> GetAll();
    }
}