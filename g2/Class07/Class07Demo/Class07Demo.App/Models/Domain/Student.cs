namespace Class07Demo.App.Models.Domain
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

    }
}
