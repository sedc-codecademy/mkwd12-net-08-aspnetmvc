using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApplication.Domain;
using TodoApplication.Dtos.Dto;

namespace TodoApplication.Mapper
{
    public static class MapperExtensions
    {
        public static CategoryDto Map(this Category category)
        {
            return new CategoryDto { Id = category.Id, Name=category.Name };
        }

        public static StatusDto Map(this Status status)
        {
            return new StatusDto { Id=status.Id, Name = status.Name };
        }
    }
}
