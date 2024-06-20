using Class07.Models.Entities;

namespace Class07.Database
{
    public class InMemoryDatabase
    {
        public static List<Student> Students { get; set; } = new List<Student>();

        static InMemoryDatabase()
        {
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
                    LastName = "bobsky",
                    DateOfBirth = DateTime.Now.AddYears(-32)
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-20)
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Todor",
                    LastName = "Pelivanov",
                    DateOfBirth = DateTime.Now.AddYears(-35)
                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Ivan",
                    LastName = "Popovski",
                    DateOfBirth = DateTime.Now.AddYears(-28)
                },
            };
        }
    }
}
