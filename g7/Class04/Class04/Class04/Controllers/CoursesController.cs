using Class04.Database;
using Class04.Models.DtoModels;
using Microsoft.AspNetCore.Mvc;

namespace Class04.Controllers
{
    [Route("courses")]
    public class CoursesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var courses = InMemoryDatabase.Courses;
            var coursesList = new List<CourseWithStudentsDto>();
            foreach (var course in courses)
            {
                var students = InMemoryDatabase.Students.Where(y => y.ActiveCourse.Id == course.Id)
                              .Select(z => new StudentDto { FullName = z.FirstName + " " + z.LastName });
                coursesList.Add(new CourseWithStudentsDto
                { Id = course.Id, Name = course.Name, Students = students.ToList() });
            }

            return View(coursesList);
        }
    }
}
