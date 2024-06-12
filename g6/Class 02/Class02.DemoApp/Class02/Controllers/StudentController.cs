using Class02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class02.Controllers
{
    #region Routing explained in comments

    // We use the Route() attribute to annotate the controller
    // and give it a different name than the class itself (StudentController)
    // in this case we need to anotate the Actions as well and we can access them 
    // in the URL like: http://localhost:port/students/all

    // We can also define a route that will follow some pattern
    // like [Route("students/[Action]")], this means that after 
    // students in the url it is expected to write the name of the Action like GetStudentName on line 45

    // If we provide routing only on the Actions and don't annotate the controller with route name
    // then we can access the routes directly by using their route name
    // like http://localhost:port/all

    #endregion

    [Route("students")]
    //[Route("students/[Action]")]
    public class StudentController : Controller
    {
        private List<Student> _students = new List<Student>
        {
            new Student()
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Bobski"
            },
            new Student()
            {
                Id = 2,
                FirstName = "Jill",
                LastName = "Jilski"
            },
            new Student()
            {
                Id = 3,
                FirstName = "John",
                LastName = "Doe"
            },
            new Student()
            {
                Id = 4,
                FirstName = "Jane",
                LastName = "Doe"
            }
        };

        public string GetStudentName()
        {
            return _students.FirstOrDefault().FirstName;
        }


        [HttpGet("all")]
        public List<Student> GetStudents()
        {
            return _students;
        }


        //[Route("{id}")]          // Route() attribute same as HttpGet()
        //[HttpGet("{id:int}")]    // Add constraint to a route
        [HttpGet("byId/{id}")]
        public Student GetStudentById(int id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }

        [HttpGet("byName/{name}")]
        public Student GetStudentByName(string name)
        {
            return _students.FirstOrDefault(x => x.FirstName == name);
        }

        [Route("{id}/{name}")]
        public Student GetStudentByIdAndNameMultioleParams(int id, string name)
        {
            return _students.FirstOrDefault(x => x.Id == id && x.FirstName == name);
        }

    }
}
