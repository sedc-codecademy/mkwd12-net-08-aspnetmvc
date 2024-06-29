using PizzaAppRefactored.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.Services.Interfaces
{
    public interface IUserService
    {
        List<UserOptionViewModel> GetAllUsersForDropdown();
    }
}
