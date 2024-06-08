using Class03_Models.Database;
using Class03_Models.Models.DtoModels;

namespace Class03_Models.Services
{
    public class CourseService
    {
        public CourseWithBestStudentDto GetCourseWithBestStudent(int courseId, int studentId)
        {
            var student = InMemoryDb.Students.FirstOrDefault(x => x.Id == studentId);
            if (student == null) return null;

            var course = InMemoryDb.Courses.FirstOrDefault(x => x.Id == courseId);
            if (course == null) return null;

            var courseWithBestStudent = new CourseWithBestStudentDto
            {
                Id = course.Id,
                CourseName = course.Name,
                StudentName = student.FirstName + student.LastName,
            };
            return courseWithBestStudent;
        }
    }
}
