using System.ComponentModel.DataAnnotations;

namespace Class07.Models.Entities
{
    public class Student
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
    }
}
