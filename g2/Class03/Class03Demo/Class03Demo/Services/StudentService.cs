using Class03Demo.Database;
using Class03Demo.Models.DomainModels;
using Class03Demo.Models.DtoModels;
using Class03Demo.Models.ViewModels;
using Class03Demo.Web.Models.DtoModels;

namespace Class03Demo.Services
{
    public class StudentService
    {
        public StudentWithCourseDto? GetStudentWithActiveCourseById(int id)
        {
            // 1) Get student by id from the database
            Student studentDb = InMemoryDb.Students.FirstOrDefault(s => s.Id == id);

            // 2) Validate if there is a student with that id
            if (studentDb is null)
            {
                return null;
            }

            // 3) MAP (transform) the Domain model into Dto model containing only the needed informations
            StudentWithCourseDto studentWithCourseDto = new StudentWithCourseDto()
            {
                Id = studentDb.Id,
                FullName = studentDb.FirstName + " " + studentDb.LastName,
                Age = DateTime.Now.Year - studentDb.DateOfBirth.Year,
                CourseName = studentDb.ActiveCourse.Name
            };

            // 4) Return the mapped Dto model to the controller
            return studentWithCourseDto;
        }

        public List<StudentViewModel> GetAllStudents()
        {
            var studentsDb = InMemoryDb.Students;

            // EXAMPLE: From scratch with foreach
            //List<StudentViewModel> mappedStudents = new();
            //foreach (var student in studentsDb)
            //{
            //    var studentViewModel = new StudentViewModel
            //    {
            //        Id = student.Id,
            //        FullName = string.Format("{0} {1}", student.FirstName, student.LastName),
            //        Course = student.ActiveCourse.Name,
            //        DateOfBirth = student.DateOfBirth.ToString("dd/MM/yyyy"),
            //    };
            //    mappedStudents.Add(studentViewModel);
            //}

            // EXAMPLE: Using LINQ method Select
            // Better way !!! (does the same thing as the code from above)
            List<StudentViewModel> mappedStudents = studentsDb.Select(s => new StudentViewModel
            {
                Id = s.Id,
                FullName = s.FirstName + " " + s.LastName,
                Course = s.ActiveCourse.Name,
                DateOfBirth = s.DateOfBirth.ToShortDateString(),
            }).ToList();

            return mappedStudents;
        }

        public StudentCourseDetailDTO? GetStudentCourseDetail(int id)
        {
            Student studentDb = InMemoryDb.Students.FirstOrDefault(s => s.Id == id);

            if (studentDb == null)
            {
                return null;
            }

            var studentCourseDto = new StudentCourseDetailDTO
            {
                StudentId = studentDb.Id,
                FullName = studentDb.FirstName + " " + studentDb.LastName,
                CourseId = studentDb.ActiveCourse.Id,
                CourseName = studentDb.ActiveCourse.Name,
                NumberOfClasses = studentDb.ActiveCourse.NumberOfClasses,
            };

            return studentCourseDto;
        }
    }
}
