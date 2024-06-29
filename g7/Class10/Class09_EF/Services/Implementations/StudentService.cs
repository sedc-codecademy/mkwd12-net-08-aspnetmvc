using Class09_EF.Dtos.StudentDtos;
using Class09_EF.Mappers;
using Class09_EF.Models.Entities;
using Class09_EF.Repositories.Interfaces;
using Class09_EF.Services.Interfaces;

namespace Class09_EF.Services.Implementations
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;

        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public async Task<AddStudentDto> CreateStudent(AddStudentDto addStudentDto)
        {
            try
            {
                var student = StudentMapper.MapFromAddStudentDtoToStudent(addStudentDto);
                await _studentRepository.Add(student);
                return addStudentDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteStudent(int id)
        {
            try
            {
                var student = await _studentRepository.GetById(id);
                await _studentRepository.Remove(student);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<StudentDto>> GetAllStudents()
        {
            List<Student> students = await _studentRepository.GetAll();
            List<StudentDto> studentDtos = new List<StudentDto>();
            foreach (var item in students)
            {
                var mappedStudent = StudentMapper.MapFromStudentToStudentDto(item);
                studentDtos.Add(mappedStudent);
            }
            return studentDtos;
        }

        public async Task<StudentDto> GetStudent(int id)
        {
            try
            {
                var student = await _studentRepository.GetById(id);
                var studentDto = StudentMapper.MapFromStudentToStudentDto(student);
                return studentDto;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<UpdateStudentDto> UpdateStudent(int id, UpdateStudentDto updateStudentDto)
        {
            try
            {
                var student = await _studentRepository.GetById(id);
                var updatedStudent = StudentMapper.MapFromUpdateStudentDtoToStudent(updateStudentDto);
                updatedStudent.Id = id;
                updatedStudent.ActiveCourseId = id;
                await _studentRepository.Update(updatedStudent);
                return updateStudentDto;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
