using Class03_Models.Services;
using Microsoft.AspNetCore.Mvc;

namespace Class03_Models.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        private StudentService _studentService;
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [Route("getstudent/{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentService.GetStudentWithActiveCourse(id);
            if (student == null) return Content("Student not found!");
            return Json(student);
        }

        [Route("getstudentname/{id}")]
        public IActionResult GetStudentName(int id)
        {
            var student = _studentService.GetStudentName(id);
            if (student == null) return Content("Student not found!");
            return Json(student);
        }
        
    }
}
