using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;
using TodoApplication.Dtos.Dto;
using TodoApplication.Mapper;
using TodoApplication.Services.Interfaces;

namespace TodoApplication.Services
{
    public class FilterService : IFilterService
    {
        private readonly IRepository<Status> _statusRepository;
        private readonly IRepository<Category> _categoryRepository;

        public FilterService(
            IRepository<Category> categoryRepository,
            IRepository<Status> statusRepository)
        {
            //    _statusRepository = new StatusRepository();
            //    _categoryRepository = new CategoryRepository();
            _statusRepository = statusRepository;
            _categoryRepository = categoryRepository;
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
