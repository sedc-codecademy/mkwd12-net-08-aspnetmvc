using Class02Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class02Demo.Controllers
{
    //ATTRIBUTE ROUTING
    [Route("student")]
    public class StudentController : Controller
    {
        private List<Student> _students = new List<Student>()
        {
            new() {Id = 1, FirstName="Bob", LastName="Bobski", DateOfBirth=DateTime.Now.AddYears(-20)},
            new() {Id = 2, FirstName="John", LastName="Johnski", DateOfBirth=DateTime.Now.AddYears(-27)},
            new() {Id = 3, FirstName="Jill", LastName="Jillski", DateOfBirth=DateTime.Now.AddYears(-30)},
            new() {Id = 4, FirstName="Jane", LastName="Janeski", DateOfBirth=DateTime.Now.AddYears(-24)}
        };

        [Route("getAllStudent")]
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            return Json(_students);
        }

        [Route("getStudents")]
        public IActionResult GetStudents()
        {
            return View();
        }

        [HttpGet("getAllStudents")]
        public IActionResult GetAllStudents()
        {
            return Json(_students);
        }

        [Route("getStudentByIdJson/{id}")]
        public IActionResult GetStudentByIdJson(int id)
        {
            return Json(_students.FirstOrDefault(x => x.Id == id));
        }

        [HttpGet("getStudentById/{id}")]
        public Student GetStudentById(int id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }

        [Route("getStudentByIdWithConstraint/{id:int}")]
        [HttpGet("getStudentByIdWithConstraint/{id:int}")]
        public Student GetStudentByIdWithConstraint(int id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }

        [Route("id/{id}/firstName/{firstName}")]
        public IActionResult GetStudentByIdAndFirstName(int id, string firstName)
        {
            var student = _students.FirstOrDefault(x => x.Id == id && x.FirstName == firstName);
            if(student != null)
            {
                return Json(student);
            }

            return RedirectToAction("GetStudents");
        }

    }
}
