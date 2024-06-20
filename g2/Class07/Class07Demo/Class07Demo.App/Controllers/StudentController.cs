using Class07Demo.App.Database;
using Class07Demo.App.Helpers;
using Class07Demo.App.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Class07Demo.App.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<StudentViewModel> mappedStudents = StaticDb.Students.Select(s => s.MapToStudentViewModel()).ToList();

            return View(mappedStudents);
        }

        [HttpGet("{id}")]
        // /students/2
        // =====> Using [FromRoute] binding attribute
        public IActionResult GetStudentById([FromRoute] int id)
        {
            var student = StaticDb.Students.FirstOrDefault(s => s.Id == id);
            StudentDetailsVM mappedStudent = student.ToStudentDetailVM();

            return View("StudentDetails", mappedStudent);
        }

        [HttpGet("filterBy")]
        // /students/filterBy?fullname=Bob Bobsky&age=31
        // =====> Using [FromQuery] binding attribute

        // ===> Example 1: Explicitly using the [FromQuery] attribute
        //public IActionResult GetStudentByQueryFilter([FromQuery] string fullName, [FromQuery] int age)
        //{
        //    var student = StaticDb.Students.FirstOrDefault(s => s.GetFullName() == fullName && (DateTime.Now.Year - s.DateOfBirth.Year) == age);

        //    return View("StudentDetails", student.ToStudentDetailVM());
        //}

        // ===> Example 2: Using custom model with it's properties being sent as query parameters
        public IActionResult GetStudentByQueryFilter([FromQuery] StudentFilterVM filter)
        {
            var student = StaticDb.Students.FirstOrDefault(s => s.GetFullName() == filter.FullName && (DateTime.Now.Year - s.DateOfBirth.Year) == filter.Age);

            return View("StudentDetails", student.ToStudentDetailVM());
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            //var createStudentVM = new CreateStudentVM();
            //return View(createStudentVM);
            return View();
        }

        [HttpPost("create")]
        // =====> Using [FromForm] binding attribute
        public IActionResult Create([FromForm] CreateStudentVM createStudentVM) 
        {
            
            StaticDb.Students.Add(createStudentVM.ToStudent());
            return RedirectToAction("Index");
        }

    }
}
