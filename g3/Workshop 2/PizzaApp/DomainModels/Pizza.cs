using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class Pizza : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
