using System;

namespace Qinshift.Asp.Net.Class06.App.Models.ViewModels
{
    public class CreateTodoVM
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
    }
}
