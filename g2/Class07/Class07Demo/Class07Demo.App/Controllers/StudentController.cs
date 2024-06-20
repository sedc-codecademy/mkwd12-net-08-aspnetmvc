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
    }
}
