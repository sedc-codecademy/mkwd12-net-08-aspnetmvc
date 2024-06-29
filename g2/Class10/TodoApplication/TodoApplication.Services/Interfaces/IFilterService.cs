using TodoApplication.Dtos.Dto;

namespace TodoApplication.Services.Interfaces
{
    public interface IFilterService
    {
        List<StatusDto> GetStatuses();
        List<CategoryDto> GetCategories();
        FilterDto GetFilterDetails();
    }
}
