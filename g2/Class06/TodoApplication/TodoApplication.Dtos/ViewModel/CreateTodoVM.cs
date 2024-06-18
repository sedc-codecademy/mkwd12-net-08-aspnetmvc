using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication.Dtos.ViewModel
{
    public class CreateTodoVM
    {
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
    }
}
