using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApplication.DataAccess;
using TodoApplication.Dtos.Dto;
using TodoApplication.Mapper;

namespace TodoApplication.Services
{
    public class FilterService
    {
        public List<StatusDto> GetStatuses()
        {
            return InMemoryDataBase.Statuses.Select(x => x.Map()).ToList();
        }

        public List<CategoryDto> GetCategories()
        {
            return InMemoryDataBase.Categories.Select(x => x.Map()).ToList();
        }

        public FilterDto GetFilterDetails()
        {
            return new FilterDto
            {
                Categories = GetCategories(),
                Statuses = GetStatuses()
            };
        }


    }
}
