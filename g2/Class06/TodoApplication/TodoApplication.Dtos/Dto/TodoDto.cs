using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication.Dtos.Dto
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
