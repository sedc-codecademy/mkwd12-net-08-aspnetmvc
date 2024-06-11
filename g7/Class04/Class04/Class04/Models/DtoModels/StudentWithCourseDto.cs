namespace Class04.Models.DtoModels
{
    public class StudentWithCourseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public int CourseId { get; set; }
        public string NameOfCourse { get; set; }

        public StudentWithCourseDto(int id, string fName, string lName, DateTime dob, int courseId, string courseName)
        {
            Id = id;
            FullName = string.Format("{0} {1}", fName, lName);
            CourseId = courseId;
            NameOfCourse = courseName;
            Age = DateTime.Now.Year - dob.Year;
        }
    }
}
