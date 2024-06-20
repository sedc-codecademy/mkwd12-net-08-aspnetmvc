using Class07Demo.App.Database;
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

        public static StudentDetailsVM ToStudentDetailVM(this Student student)
        {
            return new StudentDetailsVM
            {
                Id = student.Id,
                Email = student.Email,
                FullName = student.GetFullName(),
                Age = DateTime.Now.Year - student.DateOfBirth.Year,
                Phone = student.PhoneNumber
            };
        }

        public static Student ToStudent(this CreateStudentVM createStudentVM)
        {
            return new Student
            {
                Id = StaticDb.Students.Count + 1,
                Email = createStudentVM.Email,
                DateOfBirth = createStudentVM.DateOfBirth,
                FirstName = createStudentVM.FirstName,
                LastName = createStudentVM.LastName,
                PhoneNumber = createStudentVM.PhoneNumber
            };
        }
    }
}
