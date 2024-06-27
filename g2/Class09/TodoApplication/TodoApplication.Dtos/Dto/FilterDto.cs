namespace TodoApplication.Dtos.Dto
{
    public class FilterDto
    {
        public List<CategoryDto> Categories { get; set; }
        public List<StatusDto> Statuses { get; set; }
        public int CategoryId { get; set; } = 0;
        public int StatusId { get; set; } = 0;
    }
}
