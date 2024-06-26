using DataAccess.Interface;
using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Implementation
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected PizzaAppDbContext _dbContext;

        public Repository(PizzaAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
        }

        public T GetById(int id)
        {
            var item = _dbContext.Set<T>().AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            //var item = _dbContext.Set<T>().FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                throw new KeyNotFoundException($"Entity with id: {id} is not found");
            }

            return item;
        }

        public void Add(T entity)
        {
            _dbContext.Add(entity);
            //_dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            //_dbContext.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var item = GetById(id);
            Delete(item);
        }
    }
}
