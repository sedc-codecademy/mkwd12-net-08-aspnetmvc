using ViewModels;

namespace Class04_DemoApp
{
    public static class StaticDb
    {
        public static List<UserViewModel> Users = new List<UserViewModel>
        {
            new UserViewModel
            {
                Id = 1,
                FirstName = "Risto",
                LastName = "Panchevski"
            },new UserViewModel
            {
                Id = 2,
                FirstName = "Slave",
                LastName = "Ivanovski"
            },new UserViewModel
            {
                Id = 3,
                FirstName = "Petko",
                LastName = "Petkovski"
            }
        };
    }
}
