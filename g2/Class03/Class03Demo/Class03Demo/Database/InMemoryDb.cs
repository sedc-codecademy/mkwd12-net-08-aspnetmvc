using Class03Demo.Models.DomainModels;

namespace Class03Demo.Database
{
    public static class InMemoryDb
    {
        public static List<Student> Students { get; set; }
        public static List<Course> Courses { get; set; }

        static InMemoryDb()
        {
            SeedCourses();
            SeedStudents();
        }

        private static void SeedStudents()
        {
            Students = new List<Student>
            {
                new Student
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobski",
                    DateOfBirth = DateTime.Now.AddYears(-30).AddDays(-5).AddMonths(3),
                    ActiveCourse = Courses[3]
                },
                new Student
                {
                    Id = 2,
                    FirstName = "Jill",
                    LastName = "Jillski",
                    DateOfBirth = DateTime.Now.AddYears(-38),
                    ActiveCourse = Courses[3]
                },
                new Student
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-23).AddMonths(1),
                    ActiveCourse = Courses[3]
                },
                new Student
                {
                    Id = 4,
                    FirstName = "Jane",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-24).AddDays(-5),
                    ActiveCourse = Courses[3]
                },
            };
        }

        private static void SeedCourses()
        {
            Courses = new List<Course>
            {
                new() { Id = 1, Name = "C# Basic", NumberOfClasses = 40 },
                new() { Id = 2, Name = "C# Advanced", NumberOfClasses = 60 },
                new() { Id = 3, Name = "Database development and design", NumberOfClasses = 28 },
                new() { Id = 4, Name = "ASP.NET MVC", NumberOfClasses = 40 },
            };
        }
    }
}
