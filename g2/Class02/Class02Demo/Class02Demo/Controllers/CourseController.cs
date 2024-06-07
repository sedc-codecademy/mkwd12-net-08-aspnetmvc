using Class02Demo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class02Demo.Controllers
{
    public class CourseController : Controller
    {
        //CONVENTIONAL ROUTING
        private List<Course> _courses = new List<Course>()
        {
            new() {Id=1, Name="Csharp Basic", NumberOfClasses = 10},
            new() {Id=2, Name="Csharp Advanced", NumberOfClasses = 15},
            new() {Id=3, Name="Database", NumberOfClasses = 7},
            new() {Id=4, Name="ASP.NET MVC", NumberOfClasses = 10}
        };

        //public JsonResult GetAllCourses()
        //{
        //    return Json(_courses);
        //}

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            return Json(_courses);
        }

        public IActionResult GetCourseById(int id)
        {
            return Json(_courses.SingleOrDefault(x => x.Id == id));
        }

        public IActionResult GetCourseByIdOrName(int id, string name)
        {
            var course = _courses.FirstOrDefault(x => x.Id == id);
            
            if(course == null)
            {
                course = _courses.FirstOrDefault(x=>x.Name == name);
                if(course == null) {
                    return NoContent();
                }
                return Json(course);
            }
            else
            {
                return Json(course);
            }
        }


    }
}
