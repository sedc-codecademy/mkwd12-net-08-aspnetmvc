using TodoApplication.DataAccess.Implementations;
using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;
using TodoApplication.Dtos.Dto;
using TodoApplication.Mapper;

namespace TodoApplication.Services
{
    public class FilterService
    {
        private readonly IRepository<Status> _statusRepository;
        private readonly IRepository<Category> _categoryRepository;

        public FilterService()
        {
            _statusRepository = new StatusRepository();
            _categoryRepository = new CategoryRepository();
        }

        public List<StatusDto> GetStatuses()
        {
            return _statusRepository.GetAll().Select(x => x.Map()).ToList();
        }

        public List<CategoryDto> GetCategories()
        {
            return _categoryRepository.GetAll().Select(x => x.Map()).ToList();
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
