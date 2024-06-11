using Class04.View.Database;
using Class04.View.Models.DTOModels;
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
    }
}
