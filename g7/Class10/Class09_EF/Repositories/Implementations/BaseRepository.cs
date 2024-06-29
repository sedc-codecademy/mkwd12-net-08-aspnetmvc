using Class09_EF.DataAccess;
using Class09_EF.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Class09_EF.Repositories.Implementations
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly StudentDbContext _studentDbContext;

        public BaseRepository(StudentDbContext studentDbContext)
        {
            _studentDbContext = studentDbContext;
        }

        public async Task Add(T enitity)
        {
            try
            {
                _studentDbContext.Set<T>().Add(enitity);
                await _studentDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<T>> GetAll()
        {
            try
            {
                List<T> getAll = await _studentDbContext.Set<T>().ToListAsync();
                return getAll;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<T> GetById(int id)
        {

            try
            {
                return _studentDbContext.Set<T>().Find(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Remove(T entity)
        {

            try
            {
                _studentDbContext.Remove(entity);
                await _studentDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task SaveChanges()
        {

            try
            {
                await _studentDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Update(T entity)
        {
            try
            {
                _studentDbContext.Set<T>().Update(entity);
                await _studentDbContext.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
