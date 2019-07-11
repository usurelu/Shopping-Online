using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml.Serialization;
using log4net;
using Shopping_Online.Entities;
using Shopping_Online.Repository.InMemory;

namespace Shopping_Online.Repository.File
{
    public class FileRepository<T> : InMemoryRepository<T> where T : IEntity
    {
        private static readonly ILog Logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        protected string FilePath;

        public FileRepository(string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || filePath == string.Empty)
                throw new ArgumentNullException(nameof(filePath));

            this.FilePath = filePath;
            LoadEntities();
        }

        private void LoadEntities()
        {
            Logger.Info("Incarc entitatile din fisier");
            TextReader reader = new StreamReader(this.FilePath);
            try
            {
                XmlSerializer deserializer = new XmlSerializer(typeof(List<T>));
                List<T> entities = ((List<T>) deserializer.Deserialize(reader));
                for (int i = 0; i < entities.Count; i++)
                {
                    entities[i].SetID(i);
                    this.Entities.Add(entities[i].GetID(), entities[i]);
                }
            }
            catch (InvalidOperationException)
            {
                Logger.Info("Nu am gasit entitati, incarc lista goala");
                this.Entities = new Dictionary<int, T>();
            }
            finally
            {
                reader.Close();
            }
        }

        private void SaveEntities()
        {
            Logger.Info("Salvez entitatile in fisier");
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (TextWriter writer = new StreamWriter(this.FilePath))
            {
                serializer.Serialize(writer, this.Entities.Values.ToList());
            }
        }

        public override void Add(T entity)
        {
            Logger.Info("Adaug entitate");
            base.Add(entity);
            SaveEntities();
        }

        public override void Delete(T entity)
        {
            Logger.Info($"Sterg entitate: {entity.GetID()}");
            base.Delete(entity);
            SaveEntities();
        }
    }
}