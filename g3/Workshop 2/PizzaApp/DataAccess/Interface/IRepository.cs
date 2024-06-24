using DomainModels;

namespace DataAccess.Interface
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void DeleteById(int id);
    }
}
