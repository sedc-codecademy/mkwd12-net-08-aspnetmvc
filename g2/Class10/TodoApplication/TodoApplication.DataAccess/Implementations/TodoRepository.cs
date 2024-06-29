using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess.Implementations
{
    public class TodoRepository : ITodoRepository
    {
        public IEnumerable<Todo> GetAll()
        {
            return InMemoryDataBase.Todos;
        }

        public Todo GetById(int id)
        {
            return InMemoryDataBase.Todos.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Todo entity)
        {
            entity.Id = InMemoryDataBase.Todos.Count + 1;
            InMemoryDataBase.Todos.Add(entity);
        }

        public void Update(Todo entity)
        {
            var todo = GetById(entity.Id);
            if(todo != null)
            {
                var todoIndex = InMemoryDataBase.Todos.IndexOf(todo);
                InMemoryDataBase.Todos[todoIndex] = todo;
            }
        }

        public void Delete(int id)
        {
            var todo = GetById(id);
            if(todo != null)
            {
                InMemoryDataBase.Todos.Remove(todo);
            }
        }

        public IEnumerable<Todo> GetCompletedTodos()
        {
            return InMemoryDataBase.Todos.Where(x=> x.StatusId == 2).ToList();
        }
    }
}
