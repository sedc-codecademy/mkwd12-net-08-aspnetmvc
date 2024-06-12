using Class04.View.Database;
using Class04.View.Models.DTOModels;
using Class04.View.Models.Entities;
using Class04.View.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Class04.View.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var studetns = InMemoryDatabase.Students.Select(x => new StudentWithCourseDTO(x.Id, x.FirstName, x.LastName, x.DateOfBirth, x.ActiveCourse.Id, x.ActiveCourse.Name));
            return View(studetns);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id) 
        {
            var student = InMemoryDatabase.Students.FirstOrDefault(x => x.Id == id);
            if(student == null)
            {
                return NotFound();
            }
            var studentWithCourse = new StudentWithCourseDTO(student.Id, student.FirstName, student.LastName, student.DateOfBirth, student.ActiveCourse.Id,
                student.ActiveCourse.Name);

            return View(studentWithCourse);
        }

        [HttpGet("create")]
        public IActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost("create")]
        public IActionResult CreateStudent(CreateStudentVM createStudentVM)
        {
            var studentEntity = new Student()
            {
                Id = InMemoryDatabase.Students.Count + 1,
                FirstName = createStudentVM.FirstName,
                LastName = createStudentVM.LastName,
                DateOfBirth = createStudentVM.DateOfBirth,
                ActiveCourse = InMemoryDatabase.Courses[3]
            };

            InMemoryDatabase.Students.Add(studentEntity);
            return RedirectToAction("Index");
        }
    }
}
