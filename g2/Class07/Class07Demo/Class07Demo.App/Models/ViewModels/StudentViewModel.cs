using System.ComponentModel.DataAnnotations;

namespace Class07Demo.App.Models.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Full Name")]
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

    }
}
