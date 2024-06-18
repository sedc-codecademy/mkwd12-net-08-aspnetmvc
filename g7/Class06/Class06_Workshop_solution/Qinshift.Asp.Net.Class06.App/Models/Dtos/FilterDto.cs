using System.Collections.Generic;

namespace Qinshift.Asp.Net.Class06.App.Models.Dtos
{
    public class FilterDto
    {
        // selection options
        public List<StatusDto> Statuses { get; set; }
        public List<CategoryDto> Categories { get; set; }

        // selected values
        // default is 0 for all selection
        public int CategoryId { get; set; } = 0;
        public int StatusId { get; set; } = 0;
    }
}
