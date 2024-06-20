using System;

namespace Qinshift.Asp.Net.Class06.App.Models.Dtos
{
    public class TodoDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public int StatusId { get; set; }
    }
}
