namespace Class09_EF.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int ActiveCourseId { get; set; }

        //public virtual Course ActiveCourse { get; set; }
    }
}
