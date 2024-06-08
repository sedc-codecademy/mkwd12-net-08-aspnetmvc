namespace Class03_Models.Models.Entities
{
    //This is our Domain Entity Class Student
    //This class and its propperties will represent the data that we will write to and expect from our DB
    //e.g. Table Name => Student/s and contain Columns => Id, FirstName, LastName ...
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Course ActiveCourse { get; set; }
    }
}
