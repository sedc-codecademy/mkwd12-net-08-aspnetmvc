using Class09_EF.DataAccess;
using Microsoft.AspNetCore.Mvc;

namespace Class09_EF.Controllers
{
    [Route("students")]
    public class StudentController : Controller
    {
        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var students = _context.Students;
            return View(students);
        }
    }
}
