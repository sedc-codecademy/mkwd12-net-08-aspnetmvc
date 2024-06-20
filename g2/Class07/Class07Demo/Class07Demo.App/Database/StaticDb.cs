using Class07Demo.App.Models.Domain;

namespace Class07Demo.App.Database
{
    public static class StaticDb
    {
        public static List<Student> Students { get; private set; }

        static StaticDb()
        {
            Students = new List<Student>()
            {
                new()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    DateOfBirth = DateTime.Now.AddYears(-31),
                    Email = "bob@bobsky.com",
                    PhoneNumber = "1234567890",
                },
                new()
                {
                    Id = 2,
                    FirstName = "Jill",
                    LastName = "Wayne",
                    DateOfBirth = DateTime.Now.AddYears(-54),
                    PhoneNumber = "1231231234",
                },
                new()
                {
                    Id = 3,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-23),
                    Email = "john@doe.com",
                    PhoneNumber = "2223334444",
                }
            };
        }
    }
}
