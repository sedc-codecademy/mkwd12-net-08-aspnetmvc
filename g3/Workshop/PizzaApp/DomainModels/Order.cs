namespace DomainModels
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime Date { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
    }
}
