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

        public EFCategoryRepository()
        {
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Category.ToList();
        }

        public Category GetById(int id)
        {
            return _context.Category.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Category entity)
        {
            _context.Category.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Category entity)
        {
            _context.Category.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
