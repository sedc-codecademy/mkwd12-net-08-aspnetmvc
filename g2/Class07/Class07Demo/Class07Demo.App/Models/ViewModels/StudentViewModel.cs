using System.ComponentModel.DataAnnotations;

namespace Class07Demo.App.Models.ViewModels
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        // Specifies the display name for the FullName property
        // Typically used with Html helpers, such as in form labels or table headers, to provide more user-friendly name
        [Display(Name = "Full Name :)")]
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }

    }
}
