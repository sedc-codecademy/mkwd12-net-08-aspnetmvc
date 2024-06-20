using Qinshift.Asp.Net.Class06.App.Database;
using Qinshift.Asp.Net.Class06.App.Helpers.Mappers;
using Qinshift.Asp.Net.Class06.App.Models.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Qinshift.Asp.Net.Class06.App.Services
{
    public class FiltersService
    {
        public FilterDto GetFilterDetails()
        {
            return new FilterDto
            {
                Categories = GetCategories(),
                Statuses = GetStatuses()
            };
        }

        public List<StatusDto> GetStatuses()
        {
            return InMemoryDatabase.Statuses.Select(x => x.Map()).ToList();
        }

        public List<CategoryDto> GetCategories()
        {
            return InMemoryDatabase.Categories.Select(x => x.Map()).ToList();
        }
    }
}
