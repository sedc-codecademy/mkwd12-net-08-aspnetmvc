using PizzaAppRefactored.Domain.Models;
using PizzaAppRefactored.ViewModels.UserViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.Mappers
{
    public static class UserMapper
    {
        public static UserOptionViewModel ToUserOptionViewModel(User user)
        {
            return new UserOptionViewModel
            {
                Id = user.Id,
                UserFullName = $"{user.Firstname} {user.Lastname}"
            };
        }
    }
}
