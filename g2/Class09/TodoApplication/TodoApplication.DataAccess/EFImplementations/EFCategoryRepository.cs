using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess.EFImplementations
{
    public class EFCategoryRepository : IRepository<Category>
    {
        private readonly TodoAppDbContext _context;

        public EFCategoryRepository(TodoAppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Category> GetAll()
        {
            throw new NotImplementedException();
        }

        public Category GetById(int id)
        {
            return _context.Category.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Update(Category entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
