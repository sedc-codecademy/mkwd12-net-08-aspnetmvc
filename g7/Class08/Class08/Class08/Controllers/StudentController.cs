using Class08.Filters;
using Class08.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Class08.Controllers
{
    //[Authorize] // => This is the authorize attribute on controller level,
    //will apply to all methods inside this controller
    [Route("students")]
    public class StudentController : Controller
    {
        //[Authorize] // => this will apply to only the method bellow
        [Route("")]
        [LogAttributeFilter]
        public IActionResult Index()
        {
            if (TempData["ErrorHasHappened"] != null)
            {
                ViewData["ErrorHasHappened"] = "Something went wrong";
            }

            var students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "Todor",
                    LastName = "Pelivanov"
                },
                new Student
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe"
                },
                new Student
                {
                    Id = 3,
                    FirstName = "Ivan",
                    LastName = "Popovski"
                }
            };
            return View(students);
        }

        [HttpGet("{id}")]
        [ExceptiionAttributeFilter]
        public IActionResult GetStudentById(int id)
        {
            throw new System.Exception("Something went wrong");
        }

        //[AllowAnonymous] // => will make this method wiwthout requiring atuhorisation
        //and will override the controller level [Authorisation] attribute
        [Route("Error")]
        public IActionResult Error()
        {
            TempData["ErrorHasHappened"] = true;
            return RedirectToAction("Index");
        }
    }
}
