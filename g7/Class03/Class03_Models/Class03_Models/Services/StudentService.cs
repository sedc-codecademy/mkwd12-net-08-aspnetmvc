using Class03_Models.Database;
using Class03_Models.Models.DtoModels;

namespace Class03_Models.Services
{
    public class StudentService
    {
        public StudentWithCourseDto GetStudentWithActiveCourse(int id)
        {
            var student = InMemoryDb.Students.FirstOrDefault(x => x.Id == id);
            if (student == null)
                return null;

            var studentWithCourse = new StudentWithCourseDto
            {
                Id = student.Id,
                //FullName = student.FirstName + " " + student.LastName,
                FullName = string.Format("{0} {1}", student.FirstName, student.LastName),
                NameOfCourse = student.ActiveCourse.Name,
                Age = DateTime.Now.Year - student.DateOfBirth.Year
            };

            return studentWithCourse;
        }

        // maybe somewhere in our application we want to provide only the student Full Name, not the age and course
        public StudentNameDto GetStudentName(int id)
        {
            var student = InMemoryDb.Students.FirstOrDefault(x => x.Id == id);
            if (student == null) return null;

            var StudentFullName = new StudentNameDto
            {
                FullName = student.FirstName + " " + student.LastName
            };
            return StudentFullName;
        }
    }
}
