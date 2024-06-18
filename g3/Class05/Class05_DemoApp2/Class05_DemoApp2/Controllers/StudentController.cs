using Class05_DemoApp2.Data;
using Class05_DemoApp2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class05_DemoApp2.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            var result = StaticDb.Students;
            return View(result);
        }

        public IActionResult CreateStudent()
        {
            var emptyStudent = new StudentViewModel();
            return View(emptyStudent);
        }

        [HttpPost]
        public IActionResult CreateStudent(StudentViewModel model)
        {
            if(!ModelState.IsValid)
            {
                var firstNameProp = ModelState.FirstOrDefault(x => x.Key == "FirstName");
                if (firstNameProp.Value?.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid)
                {
                    model.FirstName = string.Empty;
                }
                return View(model);
            }

            model.Id = StaticDb.Students.Max(x => x.Id) + 1;
            StaticDb.Students.Add(model);
            return RedirectToAction("Index");
        }
    }
}
