namespace DomainModels
{
    public class UserInfo : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
    }
}
