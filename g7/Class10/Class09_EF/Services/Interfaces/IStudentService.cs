using Class09_EF.Dtos.StudentDtos;

namespace Class09_EF.Services.Interfaces
{
    public interface IStudentService
    {
        Task<AddStudentDto> CreateStudent(AddStudentDto addStudentDto);
        Task<UpdateStudentDto> UpdateStudent(int id, UpdateStudentDto updateStudentDto);
        Task DeleteStudent(int id);
        Task<List<StudentDto>> GetAllStudents();
        Task<StudentDto> GetStudent(int id);
    }
}
