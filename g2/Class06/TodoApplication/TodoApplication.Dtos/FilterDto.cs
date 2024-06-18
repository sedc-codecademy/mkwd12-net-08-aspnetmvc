using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication.Dtos
{
    public class FilterDto
    {
        public List<CategoryDto> Categories { get; set; }
        public List<StatusDto> Statuses { get; set; }
        public int CategoryId { get; set; }
        public int StatusId { get; set; }
    }
}
