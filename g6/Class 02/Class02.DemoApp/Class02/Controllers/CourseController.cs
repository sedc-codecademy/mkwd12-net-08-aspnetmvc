using Class02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class02.Controllers
{
    public class CourseController : Controller
    {
        // courses/cs
        private List<Course> _courses = new List<Course>()
        {
            new() {Id = 1, Name = "CSharp basic"},
            new() {Id = 2, Name = "CSharp advanced"},
            new() {Id = 3, Name = "Database development and design"},
            new() {Id = 4, Name = "ASP.NET MVC"},
        };

        public IActionResult GetAllCourses()
        {
            return Json(_courses);
        }


        public IActionResult GetCourseById(int id) 
        {
            return Json(_courses.FirstOrDefault(x => x.Id == id));
        }

        public IActionResult GetCourseByName(string name)
        {
            return Json(_courses.FirstOrDefault(x => x.Name.ToLower().Contains(name.ToLower())));
        }

        public IActionResult GetCourseByIdOrName(int id, string name)
        {
            var course = _courses.FirstOrDefault(x => x.Id == id);
            if (course == null)
            {
                course = _courses.FirstOrDefault(x => x.Name.ToLower().Contains(name.ToLower()));
                return Json(course);
            }
            return Json(course);
        }

    }
}
