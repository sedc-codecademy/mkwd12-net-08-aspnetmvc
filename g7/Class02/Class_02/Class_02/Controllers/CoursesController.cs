using Class_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class_02.Controllers
{
    public class CoursesController : Controller
    {
        private List<Course> _courses = new List<Course>()
        {
            new() {Id = 1, Name = "C# Basic"},
            new() {Id = 2, Name = "C# Advanced"},
            new() {Id = 3, Name = "Database development and design"},
            new() {Id = 4, Name = "ASP.NET Mvc"}
        };

        public JsonResult GetAllCourses()
        {
            return Json(_courses);
        }

        // IActionResult returns JSON
        public IActionResult GetCourseById(int id)
        {
            return Json(_courses.FirstOrDefault(c => c.Id == id));
        }

        //IActionresult returning JSON with string input
        public IActionResult GetCourseByName(string name)
        {
            return Json(_courses.FirstOrDefault(x => x.Name == name));
        }

        // This can only return a string
        public string GetCourse(int id = 1)
        {
            return _courses.FirstOrDefault(x => x.Id == id).Name;
        }

        //returning course by its id or name
        public IActionResult GetCourseByIdOrName(int id, string name)
        {
            var course = _courses.FirstOrDefault(x => x.Id == id);
            if (course == null)
            {
                course = _courses.FirstOrDefault(x => x.Name == name);
                return Json(course);
            } else
            {
                //IAcctionResult can return NoContent aswell
                return NoContent();
            }
        }
    }
}
