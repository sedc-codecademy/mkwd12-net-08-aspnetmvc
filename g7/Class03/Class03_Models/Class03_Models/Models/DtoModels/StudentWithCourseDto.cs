namespace Class03_Models.Models.DtoModels
{
    //We expose to the world our Dto model mostly because:
    //Security, the need for formatting entities
    public class StudentWithCourseDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int Age { get; set; }
        public string NameOfCourse { get; set; }
    }
}
