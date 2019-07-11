using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using log4net;
using Shopping_Online.Entities;

namespace Shopping_Online.Repository.InMemory
{
    public class InMemoryRepository<T> : IRepository<T> where T : IEntity
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected Dictionary<int, T> Entities = new Dictionary<int, T>(); 

        public int GetCount()
        {
            Logger.Info("Returnez numarul de entitati");
            return this.Entities.Count;
        }

        public T GetEntityByID(int id)
        {
            Logger.Info($"Returnez entitatea cu id-ul: {id}");
            return this.Entities.ContainsKey(id) 
                ? this.Entities[id] 
                : default(T);
        }

        public List<T> GetAll()
        {
            Logger.Info("Returnez lista de entitati");
            return this.Entities.Values.ToList();
        }

        public virtual void Add(T entity)
        {
            Logger.Info($"Adaug entitate: {entity.GetID()}");

            int entityID = this.Entities.Count;
            entity.SetID(entityID);

            this.Entities.Add(entityID, entity);
        }

        public virtual void Delete(T entity)
        {
            Logger.Info($"Sterg entitate: {entity.GetID()}");

            this.Entities.Remove(entity.GetID());
        }
    }
}