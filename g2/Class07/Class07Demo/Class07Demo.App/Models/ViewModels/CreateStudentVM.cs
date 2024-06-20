using System.ComponentModel.DataAnnotations;

namespace Class07Demo.App.Models.ViewModels
{
    public class CreateStudentVM
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }
        [MinLength(10, ErrorMessage = "NAPISI POGOLEM DESCRIPTION!")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Date of Birth is a required field!")]
        public DateTime DateOfBirth { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        //[Phone]
        [Phone(ErrorMessage = "Invalid phone number!")] // with custom Error Message
        public string PhoneNumber { get; set; }

        // More Validation Attributes: [Range], [Compare], [RegularExpression], [Url], custom-made validation attributes...

        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }
    }
}
