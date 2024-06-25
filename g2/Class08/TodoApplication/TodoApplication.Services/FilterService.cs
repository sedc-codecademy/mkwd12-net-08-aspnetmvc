using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApplication.DataAccess;
using TodoApplication.DataAccess.Implementations;
using TodoApplication.DataAccess.Intefaces;
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
            //return InMemoryDataBase.Statuses.Select(x => x.Map()).ToList();
            return _statusRepository.GetAll().Select(x => x.Map()).ToList();
        }

        public List<CategoryDto> GetCategories()
        {
            //return InMemoryDataBase.Categories.Select(x => x.Map()).ToList();
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
