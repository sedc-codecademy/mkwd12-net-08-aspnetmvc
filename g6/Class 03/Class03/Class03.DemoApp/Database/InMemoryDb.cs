using Class03.DemoApp.Models.Entities;

namespace Class03.DemoApp.Database
{
    public static class InMemoryDb
    {
        static InMemoryDb()
        {
            LoadCourses();
            LoadStudents();
        }

        public static List<Student> Students { get; set; }
        public static List<Course> Courses { get; set; }



        private static void LoadStudents() 
        {
            Students = new List<Student>
            {
                new()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    ActiveCourse = Courses[2]
                },
                new()
                {
                    Id = 2,
                    FirstName = "Jill",
                    LastName = "Jilsky",
                    DateOfBirth = DateTime.Now.AddYears(-17),
                    ActiveCourse = Courses[3]
                },
                new()
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-30),
                    ActiveCourse = Courses[1]
                },
                new()
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-14),
                    ActiveCourse = Courses[2]
                }
            };
        }

        private static void LoadCourses() 
        {
            Courses = new List<Course>
            {
                new() {Id = 1, Name = "CSharp basic", NumberOfClasses = 10},
                new() {Id = 2, Name = "CSharp advanced", NumberOfClasses = 15},
                new() {Id = 3, Name = "Database development and design", NumberOfClasses = 7},
                new() {Id = 4, Name = "ASP.NET MVC", NumberOfClasses = 10},
            };
        }


    }
}
