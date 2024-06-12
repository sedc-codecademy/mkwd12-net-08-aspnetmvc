using Class04.View.Models.Entities;

namespace Class04.View.Database
{
    public class InMemoryDatabase
    {
        public static List<Student> Students { get; set; }
        public static List<Course> Courses { get; set; }

        static InMemoryDatabase()
        {
            LoadCourses();
            LoadStudents();
        }

        private static void LoadStudents()
        {
            Students = new List<Student>
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobski",
                    DateOfBirth = DateTime.Now.AddYears(-27),
                    ActiveCourse = Courses[3]
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Jill",
                    LastName = "Jilski",
                    DateOfBirth = DateTime.Now.AddYears(-37),
                    ActiveCourse = Courses[3]
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-45),
                    ActiveCourse = Courses[3]
                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-17),
                    ActiveCourse = Courses[3]
                },
            };
        }

        private static void LoadCourses()
        {
            Courses = new List<Course>()
            {
                new() { Id = 1, Name = "C# basic", NumberOfClasses = 40 },
                new() { Id = 2, Name = "C# Advanced", NumberOfClasses = 60 },
                new() { Id = 3, Name = "Database development and design", NumberOfClasses = 28 },
                new() { Id = 4, Name = "ASP.NET Mvc", NumberOfClasses = 40 }
            };
        }

    }
}
