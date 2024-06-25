using PizzaAppRefactored.DataAccess;
using PizzaAppRefactored.Domain.Models;
using PizzaAppRefactored.Mappers;
using PizzaAppRefactored.Services.Interfaces;
using PizzaAppRefactored.ViewModels.UserViewModels;

namespace PizzaAppRefactored.Services.Implementations
{
    public class UserService : IUserService
    {
        private IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public List<UserOptionViewModel> GetAllUsersForDropdown()
        {
            List<User> users = _userRepository.GetAll();

            List<UserOptionViewModel> userOptionViewModels = users.Select(x => UserMapper.ToUserOptionViewModel(x)).ToList();

            return userOptionViewModels;
        }
    }
}
