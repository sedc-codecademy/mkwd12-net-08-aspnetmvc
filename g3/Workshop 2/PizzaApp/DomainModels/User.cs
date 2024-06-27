using System.ComponentModel.DataAnnotations;

namespace DomainModels
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{FirstName} {LastName}";
        public int RoleId { get; set; }
        public Role Role { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
    }
}
