using Class03.DemoApp.Database;
using Class03.DemoApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Class03.DemoApp.Controllers
{
    public class StudentController : Controller
    {

        private StudentService _studentService;
        public StudentController()
        {
            _studentService = new StudentService();
        }

        //Bad practice! 
        //Avoid access to db in the controller actions
        public IActionResult GetAllStudents()
        {
            return Json(InMemoryDb.Students);
        }

        public IActionResult GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);
            if(student != null)
                return Json(student);
            return NotFound();
        }

        public IActionResult GetStudentDetails(int id)
        {
            var studentDetails = _studentService.GetStudentWithCourse(id);

            if (studentDetails == null)
                return Content("Student not found!");
            return Json(studentDetails);
        }
    }
}
