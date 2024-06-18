using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Class05_DemoApp2.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("First name")]
        [RegularExpression("[a-zA-Z]+", ErrorMessage = "Името мора да е составено само од букви")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Полето за презиме е задолжително")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression("F|M", ErrorMessage = "Gender should be F or M")]
        public char Gender { get; set; }
        [Required]
        public GroupEnum Group { get; set; }
    }
}
