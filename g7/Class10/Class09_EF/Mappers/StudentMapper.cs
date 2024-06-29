using Class09_EF.Dtos.StudentDtos;
using Class09_EF.Models.Entities;

namespace Class09_EF.Mappers
{
    public static class StudentMapper
    {
        //mapping from student to AddStudentDto
        public static Student MapFromAddStudentDtoToStudent(AddStudentDto addStudentDto)
        {
            return new Student
            {
                FirstName = addStudentDto.FirstName,
                LastName = addStudentDto.LastName,
                DateOfBirth = addStudentDto.DateOfBirth,
                ActiveCourseId = addStudentDto.ActiveCourseId,
            };
        }

        //mapping from addStudentDto to Student
        public static AddStudentDto MapFromAddStudentDtoToStudent(Student student)
        {
            return new AddStudentDto
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                ActiveCourseId = student.ActiveCourseId,
            };
        }

        //Mapping from Student to studentdto
        public static StudentDto MapFromStudentToStudentDto(Student student)
        {
            return new StudentDto
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                DateOfBirth = student.DateOfBirth,
                ActiveCourseId = student.ActiveCourseId
            };
        }

        // Mapping from StudentDto to Student 
        public static Student MapFromStudentDtoToStudent(StudentDto studentDto)
        {
            return new Student
            {
                Id = studentDto.Id,
                FirstName = studentDto.FirstName,
                LastName = studentDto.LastName,
                DateOfBirth = studentDto.DateOfBirth,
                ActiveCourseId = studentDto.ActiveCourseId
            };
        }

        //Mapping from UpdateStudentDto to Student
        public static Student MapFromUpdateStudentDtoToStudent(UpdateStudentDto updateStudentDto)
        {
            Student updatedStudent = new Student();
            updatedStudent.FirstName = updateStudentDto.FirstName;
            updatedStudent.LastName = updateStudentDto.LastName;
            updatedStudent.DateOfBirth = updateStudentDto.DateOfBirth;
            return updatedStudent;
        }
    }
}
