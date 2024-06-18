using Class06_Workshop.Models.Entities;

namespace Class06_Workshop.Database
{
    public static class InMemoryDatabase
    {
        public static List<Category> Categories { get; private set; }
        public static List<Status> Statuses { get; private set; }
        public static List<Todo> Todos { get; set; }

        static InMemoryDatabase()
        {
            LoadCategories();
            LoadStatuses();
            LoadTodos();
        }


        private static void LoadCategories()
        {
            Categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Work",
                },
                new Category
                {
                    Id = 2,
                    Name = "Home",
                },
                new Category
                {
                    Id = 3,
                    Name = "Exercise",
                },
                new Category
                {
                    Id = 4,
                    Name = "Shopping",
                },
                new Category
                {
                    Id = 5,
                    Name = "Hobbie",
                },
                new Category
                {
                    Id = 6,
                    Name = "Freetime",
                }
            };
        }

        private static void LoadStatuses()
        {
            Statuses = new List<Status>
            {
                new Status { Id = 1, Name = "Open" }, new Status { Id = 2, Name = "Closed" }
            };
        }
        private static void LoadTodos()
        {
            Todos = new List<Todo> { new Todo { Id = 1, Description = "Test todo", CategoryId = 1, StatusId = 1, DueDate = DateTime.Now.AddDays(2) } };
        }
    }
}
