namespace Class04.View.Models.DTOModels
{
    public class StudentWithCourseDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int CourseId { get; set; }
        public string NameOfCourse { get; set; }

        public StudentWithCourseDTO(int id, string firstName, string lastName, DateTime birthDateTime, int courseId, string nameofCourse)
        {
            Id = id;
            FullName = string.Format("{0} {1}", firstName, lastName); // firstName + " " + lastName
            CourseId = courseId;
            Age = DateTime.Now.Year - birthDateTime.Year;
            NameOfCourse = nameofCourse;
        }



    }
}
