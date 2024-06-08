namespace Class03Demo.Models.ViewModels
{
    // would be used in a view for creating new students
    public class CreateStudentViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
