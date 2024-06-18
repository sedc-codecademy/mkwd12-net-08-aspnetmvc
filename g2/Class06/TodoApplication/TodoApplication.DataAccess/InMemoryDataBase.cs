using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess
{
    public static class InMemoryDataBase
    {
        public static List<Category> Categories { get; set; }
        public static List<Status> Statuses { get; set; }
        public static List<Todo> Todos { get; set; }

        static InMemoryDataBase()
        {
            LoadCategories();
            LoadStatuses();
            LoadTodos();
        }

        private static void LoadCategories()
        {
            Categories = new List<Category>()
            {
                new Category {Id=1, Name="Work"},
                new Category {Id=2, Name="Home"},
                new Category {Id=3, Name="Exercise"},
                new Category {Id=4, Name="Hobbie"},
                new Category {Id=5, Name="Shopping"},
                new Category {Id=6, Name="Freetime"},
                new Category {Id=7, Name="Homework"}

            };
        }

        private static void LoadStatuses()
        {
            Statuses = new List<Status>()
            {
                new Status(){Id=1, Name="In Progress"},
                new Status(){Id=2, Name="Completed"}
            };
        }

        private static void LoadTodos()
        {
            Todos = new List<Todo>()
            {
                new Todo(){Id=1, Description="Test todo", DueDate=DateTime.Now.AddDays(3), CategoryId=1, StatusId=1},
                new Todo(){Id=2, Description="Homework PizzaApp", DueDate=DateTime.Now.AddDays(-5), CategoryId=7, StatusId=2}
            };
        }
    }
}
