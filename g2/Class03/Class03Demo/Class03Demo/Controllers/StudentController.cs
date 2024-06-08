using Class03Demo.Models.DtoModels;
using Class03Demo.Models.ViewModels;
using Class03Demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Class03Demo.Controllers
{
    //[Route("students")] // custom route name for our controller
    [Route("[controller]/[action]")] // set routing to be "controllerName/actionName"
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController()
        {
            _studentService = new StudentService();
        }

        // /students/2 (if Route("students") is used)
        // /student/GetStudentById/1
        [HttpGet("{id}")] 
        public IActionResult GetStudentById(int id)
        {
            // 1) Process the request to the Service layer (StudentService)
            StudentWithCourseDto studentDto = _studentService.GetStudentWithActiveCourseById(id);

            // 2) Return error message if no student found with that id
            if (studentDto == null)
            {
                return Content("Student not found!");
            }

            // 3) Return Json object of the mapped student 
            return Json(studentDto);
        }

        // /student/getallstudents
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            List<StudentViewModel> students = _studentService.GetAllStudents();

            // return View(students);
            // NOTE: Handling the ViewModel in the View, as well as creating Views will be discussed in the following lectures
            return Json(students);
        }

        // EXERCISE 01
        // /student/GetStudentCourseDetails/1
        [HttpGet("{id}")]
        public IActionResult GetStudentCourseDetails(int id)
        {
            var studentCourseDetails = _studentService.GetStudentCourseDetail(id);

            if (studentCourseDetails is null)
            {
                return Content("No user found!");
            }

            return Json(studentCourseDetails);
        }
    }
}
