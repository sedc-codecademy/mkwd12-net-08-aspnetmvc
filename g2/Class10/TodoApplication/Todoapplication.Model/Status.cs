namespace TodoApplication.Domain
{
    public class Status : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
