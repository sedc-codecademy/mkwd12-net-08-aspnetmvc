using TodoApplication.Domain;

namespace TodoApplication.DataAccess.Interfaces
{
    public interface ITodoRepository : IRepository<Todo>
    {
        IEnumerable<Todo> GetCompletedTodos();
    }
}
