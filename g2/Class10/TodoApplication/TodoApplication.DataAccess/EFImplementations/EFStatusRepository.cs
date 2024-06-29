using Microsoft.EntityFrameworkCore;
using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess.EFImplementations
{
    public class EFStatusRepository : IRepository<Status>
    {
        private readonly TodoAppDbContext _context;

        public EFStatusRepository(TodoAppDbContext context)
        {
            _context = context;
        }

        public EFStatusRepository()
        {
        }

        public IEnumerable<Status> GetAll()
        {
            return _context.Status.ToList();
        }

        public Status GetById(int id)
        {
            //using (var dbContext = new TodoAppDbContext())
            //{
            //    return dbContext.Status.FirstOrDefault(s => s.Id == id);
            //}
            return _context.Status.FirstOrDefault(s => s.Id == id);
        }

        public void Add(Status entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update(Status entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
