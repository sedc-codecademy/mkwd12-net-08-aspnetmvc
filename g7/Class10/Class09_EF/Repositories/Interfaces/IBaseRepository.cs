namespace Class09_EF.Repositories.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task Add(T entity);
        Task Remove(T entity);
        Task Update (T entity);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task SaveChanges();
    }
}
