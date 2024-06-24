using DataAccess.Interface;
using DomainModels;
using Newtonsoft.Json;

namespace DataAccess.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        public List<T> GetAll()
        {
            return ReadContent();
        }

        public T GetById(int id)
        {
            var items = ReadContent();
            var item = items.FirstOrDefault(x => x.Id == id);

            if(item == null)
            {
                throw new KeyNotFoundException($"Entity with id: {id} is not found");
            }
            return item;
        }

        public void Update(T entity)
        {
            var items = ReadContent();

            var item = items.FirstOrDefault(x => x.Id == entity.Id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Entity with id: {entity.Id} is not found");
            }

            var indexOfItem = items.IndexOf(item);

            items[indexOfItem] = entity;
            WriteContent(items);
        }

        public void Add(T entity)
        {
            var items = ReadContent();
            var nextId = items.Max(x => x.Id) + 1;

            entity.Id = nextId;

            items.Add(entity);
            WriteContent(items);
        }

        public void Delete(T entity)
        {
            DeleteById(entity.Id);
        }

        public void DeleteById(int id)
        {
            var items = ReadContent();

            var item = items.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Entity with id: {id} is not found");
            }

            items.Remove(item);
            WriteContent(items);
        }

        public List<T> ReadContent()
        {
            string folderPath = Environment.CurrentDirectory + @"\Data\";
            string filePath = folderPath + typeof(T).Name + "s.json";
            List<T> items = new List<T>();

            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if(!File.Exists(filePath))
            {
                return items;
            }

            using(var sr = new StreamReader(filePath))
            {
                var content = sr.ReadToEnd();
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                items = JsonConvert.DeserializeObject<List<T>>(content, settings);
               
            }

            return items;
        }

        public void WriteContent(List<T> items)
        {
            string folderPath = Environment.CurrentDirectory + @"\Data\";
            string filePath = folderPath + typeof(T).Name + "s.json";

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            using(var sw = new StreamWriter(filePath))
            {
                JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
                var content = JsonConvert.SerializeObject(items, settings);
                sw.WriteLine(content);
            }
        }
    }
}
