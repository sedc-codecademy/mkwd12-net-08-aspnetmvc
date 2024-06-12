using Class03.DemoApp.Database;
using Class03.DemoApp.Models.ViewModels;

namespace Class03.DemoApp.Services
{
    public class CourseService
    {
        public List<CourseViewModel> GetCoursesWithMoreThanTenClasses()
        {
            var courses = InMemoryDb.Courses.Where(x => x.NumberOfClasses > 7).ToList();

            List<CourseViewModel> result = new List<CourseViewModel>();

            if(courses.Count > 0)
            {
                foreach(var course in courses)
                {
                    result.Add(new CourseViewModel
                    {
                        Name = course.Name,
                        NumberOfClasses = course.NumberOfClasses,
                    });
                }
            }
            return result;
        }
    }
}
