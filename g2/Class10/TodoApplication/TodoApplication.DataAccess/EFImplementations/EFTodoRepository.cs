using Microsoft.EntityFrameworkCore;
using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess.EFImplementations
{
    public class EFTodoRepository : ITodoRepository
    {
        private readonly TodoAppDbContext _context;

        public EFTodoRepository(TodoAppDbContext context)
        {
            _context = context;
        }

        public EFTodoRepository()
        {
        }

        public IEnumerable<Todo> GetAll()
        {
            // => Retrives only Todo items, without theri Category and Status
            //return _context.Todo.ToList();
            // ===> SQL translation:
            //select * from dbo.Todo t

            // => Retrieves all Todo items, including their Category and Status
            return _context.Todo
                .Include(t => t.Category)
                .Include(t => t.Status)
                .ToList();
            // ===> SQL translation:
            //select* from dbo.Todo t
            //inner join dbo.Status s on s.Id = t.StatusId
            //inner join dbo.Category c on c.Id = t.CategoryId
        }

        // Retrieves a specific Todo item by its Id, including its Category and Status
        public Todo GetById(int id)
        {
            return _context.Todo
                .Include(t => t.Status)
                .Include(t => t.Category)
                .FirstOrDefault(t => t.Id == id)!;
            // ===> SQL translation: 
            // SELECT * FROM Todo t
            // JOIN Category c ON c.Id = t.CategoryId
            // JOIN Status s ON s.Id = t.StatusId
            // WHERE t.Id = @id
        }

        // Adds the new Todo entity to the DbSet and saves changes to the database
        public void Add(Todo entity)
        {
            _context.Todo.Add(entity);
            _context.SaveChanges();
            // ===> SQL translation: 
            // INSERT INTO Todo (* columns names *)
            // VALUES (* values from entity *)
        }

        // Updates an existing Todo item in the database and saves the changes
        public void Update(Todo entity)
        {
            _context.Todo.Update(entity);
            _context.SaveChanges();
            // ===> SQL translation: 
            // UPDATE Todo SET *Columns = Values from entity*
            // WHERE Id = @entity.Id
        }

        // Deletes a Todo item by its Id
        public void Delete(int id)
        {
            Todo todoDb = GetById(id);
            if (todoDb != null)
            {
                _context.Todo.Remove(todoDb); // Hard Delete (rarely used)
                _context.SaveChanges();
            }
        }

        // Retrieves all completed Todo items
        public IEnumerable<Todo> GetCompletedTodos()
        {
            return _context.Todo
                .Include(t => t.Status)
                .Include(t => t.Category)
                .Where(t => t.Status.Name == "Completed")
                .ToList();
        }

    }
}
