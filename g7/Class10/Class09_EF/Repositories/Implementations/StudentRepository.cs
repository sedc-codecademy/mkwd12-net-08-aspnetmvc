using Class09_EF.DataAccess;
using Class09_EF.Models.Entities;
using Class09_EF.Repositories.Interfaces;

namespace Class09_EF.Repositories.Implementations
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly StudentDbContext _studentDbContext;

        public StudentRepository(StudentDbContext studentDbContext) : base(studentDbContext) 
        {
            _studentDbContext = studentDbContext;
        }

        //implementation of custom repository methods, if any, will happen here
    }
}
