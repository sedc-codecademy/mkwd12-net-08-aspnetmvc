using Class09_EF.Dtos.StudentDtos;
using Class09_EF.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Class09_EF.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var students = await _studentService.GetAllStudents();
            return View(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetStudentById(int id)
        {
            var student = await _studentService.GetStudent(id);
            if (student == null) return View();

            return View("GetStudentById", student);
        }

        [HttpGet("create")]
        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(AddStudentDto addStudentDto)
        {
            await _studentService.CreateStudent(addStudentDto);
            return RedirectToAction("Index");
        }

        [HttpPost("{id}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _studentService.DeleteStudent(id);
            return RedirectToAction("Index");
        }
    }
}
