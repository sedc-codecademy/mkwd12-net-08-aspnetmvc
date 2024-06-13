using Class05_DemoApp2.Models;

namespace Class05_DemoApp2.Data
{
    public static class StaticDb
    {
        public static List<StudentViewModel> Students = new List<StudentViewModel>()
        {
            new StudentViewModel
            {
                Id = 1,
                FirstName ="Risto",
                LastName = "Panchevski",
                Gender = 'M',
                Group = GroupEnum.G3
            }
        };
    }
}
