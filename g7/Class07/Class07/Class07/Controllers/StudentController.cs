using Class07.Database;
using Class07.Models.Dtos;
using Class07.Models.Entities;
using Class07.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Class07.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = InMemoryDatabase.Students;
            List<StudentDto> studentsDto = new List<StudentDto>();

            foreach (var student in students)
            {
                var mappedStudent = new StudentDto();
                mappedStudent.FullName = student.FirstName + " " + student.LastName;
                mappedStudent.Age = DateTime.Now.Year - student.DateOfBirth.Year;
                studentsDto.Add(mappedStudent);
            }
            return View(studentsDto);
        }

        [HttpGet("create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create([FromForm] CreateStudentVM model)
        {
            //this is used with FromForm and FromBody
            if (ModelState.IsValid)
            {
                //Logic to save the student to the database
                //since this is only for demo purposes, we will return the following success message
                return Content("Student created successfully");
            }
            return View(model); // if model is not valid, return the view with validation errors
        }

        // https://localhost:7111/student/2 getting with id
        [Route("{id}")]
        public IActionResult GetStudent([FromRoute] int id)
        {
            var student = new StudentDto();

            if (id != null && id <= InMemoryDatabase.Students.Count())
            {
                var studentWithId = InMemoryDatabase.Students.Where(x => x.Id == id).FirstOrDefault();
                if (studentWithId != null)
                {
                    student.FullName = studentWithId.FirstName + " " + studentWithId.LastName;
                    student.Age = DateTime.Now.Year - studentWithId.DateOfBirth.Year;
                    return View(student);
                }

            }
            return Content("No student in database with the provided id");
            //return RedirectToAction("Index");
        }

        // https://localhost:7111/student/getfromquery?FirstName=John&Age=20 how can you use query params
        [HttpGet("getfromquery")]
        public IActionResult GetStudent([FromQuery] StudentFilterVM filter)
        {
            var student = new StudentDto();

            if(filter != null && !string.IsNullOrEmpty(filter.FirstName) && filter.Age > 0) {
                var studentWithFilter = InMemoryDatabase.Students
                    .Where(x => x.FirstName == filter.FirstName && (DateTime.Now.Year - x.DateOfBirth.Year) == filter.Age)
                    .FirstOrDefault();
                if(studentWithFilter != null)
                {
                    student.FullName = studentWithFilter.FirstName + " " + studentWithFilter.LastName;
                    //student.Age = filter.Age;
                    student.Age = DateTime.Now.Year - studentWithFilter.DateOfBirth.Year;
                    return View(student);
                }
            }

            return Content("No such student with given firstname and age");


        }
    }
}
