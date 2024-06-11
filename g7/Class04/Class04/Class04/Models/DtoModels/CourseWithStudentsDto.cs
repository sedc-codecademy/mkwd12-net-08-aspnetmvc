namespace Class04.Models.DtoModels
{
    public class CourseWithStudentsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<StudentDto> Students { get; set; }
        public CourseWithStudentsDto()
        {
            Students = new List<StudentDto>();
        }
    }
}
