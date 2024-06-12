using Class04.Database;
using Class04.Models.DtoModels;
using Class04.Models.Entities;
using Class04.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Class04.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View(InMemoryDatabase.Students.Select(x => new StudentWithCourseDto(x.Id, 
                                                                                       x.FirstName,
                                                                                       x.LastName,
                                                                                       x.DateOfBirth,
                                                                                       x.ActiveCourse.Id,
                                                                                       x.ActiveCourse.Name)));
        }

        [HttpGet("{id}")]
        public ActionResult GetStudentById(int id)
        {
            var student = InMemoryDatabase.Students.FirstOrDefault(x => x.Id == id);
            if (student == null) return View();

            var studentWithCourse = new StudentWithCourseDto(student.Id,
                                                              student.FirstName,
                                                              student.LastName,
                                                              student.DateOfBirth,
                                                              student.ActiveCourse.Id,
                                                              student.ActiveCourse.Name);
            return View(studentWithCourse);
        }

        [HttpGet("create")]
        public ActionResult CreateStudent()
        {
            return View("CreateStudent");
        }

        [HttpPost("create")]
        public IActionResult CreateStudent(CreateStudentVM viewModel)
        {
            var entity = new Student
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                DateOfBirth = viewModel.DateOfBirth,
                Id = InMemoryDatabase.Students.Count + 1,
                ActiveCourse = InMemoryDatabase.Courses[3]
            };

            InMemoryDatabase.Students.Add(entity);
            return RedirectToAction("Index");
        }
    }
}
