using Class03.DemoApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace Class03.DemoApp.Controllers
{
    [Route("courses")]
    public class CourseController : Controller
    {
        private CourseService _courseService;

        public CourseController()
        {
            _courseService = new CourseService();
        }

        [HttpGet("getcourses")]
        public IActionResult GetCourses()
        {
            var courses = _courseService.GetCoursesWithMoreThanTenClasses();
            if(courses != null && courses.Any())
            {
                return View(courses);
                //return Json(courses);
            }
            return Content("No courses available!");
        }
    }
}
