namespace Class04.View.Models.DTOModels
{
    public class CourseWithStudentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<StudentDTO> Students { get; set; }

        public CourseWithStudentDTO()
        {
            Students = new List<StudentDTO>();
        }

    }
}
