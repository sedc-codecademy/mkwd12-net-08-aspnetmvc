using System.ComponentModel.DataAnnotations;

namespace Class07.Models.ViewModels
{
    public class CreateStudentVM
    {
        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(25)]
        [Display(Name = "LastName")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = " The Length must be at least {2} characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "ConfirmPassword")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

    }
}
