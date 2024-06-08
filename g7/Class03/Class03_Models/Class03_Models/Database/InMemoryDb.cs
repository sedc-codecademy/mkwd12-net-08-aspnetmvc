using Class03_Models.Models.Entities;

namespace Class03_Models.Database
{
    public static class InMemoryDb
    {
        public static List<Student> Students { get; set; } = new List<Student>();
        public static List<Course> Courses { get; set; } = new List<Course>();

        static InMemoryDb()
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
                    LastName = "Bobsky",
                    DateOfBirth = DateTime.Now.AddYears(-28),
                    ActiveCourse = Courses[3]
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "Jill",
                    LastName = "Jillsky",
                    DateOfBirth = DateTime.Now.AddYears(-30),
                    ActiveCourse = Courses[3]
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Todor",
                    LastName = "Pelivanov",
                    DateOfBirth = DateTime.Now.AddYears(-35),
                    ActiveCourse = Courses[2]
                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Ilija",
                    LastName = "Ruseski",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    ActiveCourse = Courses[1]
                 }
            };
        }

        private static void LoadCourses()
        {
            Courses = new List<Course>()
            {
                new() { Id = 1, Name = "C# basic", NumberOfClasses = 40},
                new() { Id = 2, Name = "C# advanced", NumberOfClasses = 60},
                new() { Id = 3, Name = "Database development and design", NumberOfClasses = 28},
                new() { Id = 4, Name = "ASP.NET Mvc", NumberOfClasses = 40}
            };
        }
    }
}
