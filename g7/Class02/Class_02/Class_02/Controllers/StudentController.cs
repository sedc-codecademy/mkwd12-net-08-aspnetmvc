using Class_02.Models;
using Microsoft.AspNetCore.Mvc;

namespace Class_02.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        //creating our data sourse for demo purposes =>
        //p.s. in real-time we are going to get the data from a database, not like this

        private List<Student> _students = new List<Student>
        {
            new Student()
            {
                Id = 1,
                FirstName = "Bob",
                LastName = "Bobski",
                DateOfBirth = DateTime.Now.AddYears(-27)
            },
            new Student()
            {
                Id = 2,
                FirstName = "Jill",
                LastName = "Jillsky",
                DateOfBirth = DateTime.Now.AddYears(-76)
            },
            new Student()
            {
                Id = 3,
                FirstName = "Frosina",
                LastName = "Stamenkovska",
                DateOfBirth = DateTime.Now.AddYears(-20)
            },
            new Student()
            {
                Id = 4,
                FirstName = "Sylvester",
                LastName = "Stallone",
                DateOfBirth = DateTime.Now.AddYears(-68)
            },
        };

        public string GetStudentName()
        {
            return _students.FirstOrDefault().FirstName;
        }

        //route without parameters
        [Route("all")]
        //[HttpGet("all")]
        public List<Student> GetStudents()
        {
            return _students;
        }

        //route with parameter without contraint
        //[Route("{id}")]
        [HttpGet("{id}")] // other way to use attribute routing => go with this way
        public Student GetStudentById(int id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }

        // add a route with parameter with contraint
        [Route("byId/constraint/{id:int}")]
        public Student getStudentByIdWithConstraint(int id)
        {
            return _students.FirstOrDefault(x => x.Id == id);
        }

        // add a route with parameter with default value
        [Route("byId/default/{id}")]
        public Student GetStudentByIdWithDefaultValue(int id = 1)
        {
            return _students.FirstOrDefault(t => t.Id == id);
        }

        //add multiple parameter route
        [Route("{id}/{name}")]
        public Student GetStudentByIdAndNameMultipleParams(int id, string name)
        {
            return _students.FirstOrDefault(x => x.Id == id && x.FirstName == name);
        }

    }
}
