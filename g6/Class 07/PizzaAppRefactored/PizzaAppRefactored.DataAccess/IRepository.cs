namespace PizzaAppRefactored.DataAccess
{
    public interface IRepository<T>
    {
        //CRUD - create, read, update, delete
        List<T> GetAll();

        T GetById(int id);

        int Insert(T entity);

        void Update(T entity);

        void DeleteById(int id);

    }
}
