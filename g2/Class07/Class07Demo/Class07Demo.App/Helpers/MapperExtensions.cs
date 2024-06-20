using Class07Demo.App.Models.Domain;
using Class07Demo.App.Models.ViewModels;

namespace Class07Demo.App.Helpers
{
    public static class MapperExtensions
    {
        public static StudentViewModel MapToStudentViewModel(this Student student)
        {
            return new StudentViewModel
            {
                Id = student.Id,
                Email = student.Email,
                FullName = student.GetFullName(),
                Age = DateTime.Now.Year - student.DateOfBirth.Year
            };
        }
    }
}
