using Class09_EF.Models.Entities;

namespace Class09_EF.Repositories.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        //here inside if we need specific methods for student, we will add them here
    }
}
