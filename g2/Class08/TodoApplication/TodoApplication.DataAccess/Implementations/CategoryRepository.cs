using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApplication.DataAccess.Intefaces;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess.Implementations
{
    public class CategoryRepository : IRepository<Category>
    {
        public IEnumerable<Category> GetAll()
        {
            return InMemoryDataBase.Categories;
        }
        public Category GetById(int id)
        {
            return InMemoryDataBase.Categories.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Category entity)
        {
            entity.Id = InMemoryDataBase.Categories.Count + 1;
            InMemoryDataBase.Categories.Add(entity);
        }

        public void Update(Category entity)
        {
            var category = GetById(entity.Id);
            if(category != null)
            {
                var categoryIndex = InMemoryDataBase.Categories.IndexOf(category);
                InMemoryDataBase.Categories[categoryIndex] = entity;
            }
        }

        public void Delete(int id)
        {
            var category = GetById(id);
            if(category != null)
            {
                InMemoryDataBase.Categories.Remove(category);
            }
        }
    }
}
