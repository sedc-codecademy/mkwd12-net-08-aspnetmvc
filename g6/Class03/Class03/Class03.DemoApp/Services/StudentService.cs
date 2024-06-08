using Class03.DemoApp.Database;
using Class03.DemoApp.Models.DtoModels;
using Class03.DemoApp.Models.Entities;

namespace Class03.DemoApp.Services
{
    public class StudentService
    {

        public Student GetStudentById(int id)
        {
            return InMemoryDb.Students.SingleOrDefault(x => x.Id == id);
        }

        public StudentWithCourseDto GetStudentWithCourse(int id)
        {
            Student student = InMemoryDb.Students.SingleOrDefault(x => x.Id == id);

            if(student == null)
            {
                return null;
            }

            var studentWithCourse = new StudentWithCourseDto
            {
                Id = student.Id,
                FullName = string.Format("{0} {1}", student.FirstName, student.LastName),
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                NameOfActiveCourse = student.ActiveCourse.Name
            };

            return studentWithCourse;
        }
    }
}
