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

        public IEnumerable<Status> GetAll()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Update(Status entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

    }
}
