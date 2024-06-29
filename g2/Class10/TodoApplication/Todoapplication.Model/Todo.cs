using System.ComponentModel.DataAnnotations;

namespace TodoApplication.Domain
{
    public class Todo : BaseEntity
    {
        [MaxLength(1000)]
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
