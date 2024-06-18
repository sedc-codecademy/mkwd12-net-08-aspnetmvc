using Qinshift.Asp.Net.Class06.App.Models.Dtos;
using Qinshift.Asp.Net.Class06.App.Models.Entities;

namespace Qinshift.Asp.Net.Class06.App.Helpers.Mappers
{
    public static class MappersExtensions
    {
        public static CategoryDto Map(this Category category)
        {
            return new CategoryDto { Id = category.Id, Name = category.Name };
        }

        public static StatusDto Map(this Status status)
        {
            return new StatusDto { Id = status.Id, Name = status.Name };
        }
    }
}
