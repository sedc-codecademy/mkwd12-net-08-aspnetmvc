namespace DomainModels
{
    public class Pizza : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
