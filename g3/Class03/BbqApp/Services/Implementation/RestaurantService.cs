using DataAccess.Implementation;
using DataAccess.Interfaces;
using DomainModels;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModels;

namespace Services.Implementation
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRepository<Restaurant> _restaurantRepository;

        public RestaurantService()
        {
            _restaurantRepository = new RestaurantRepository();
        }

        public RestaurantViewModel GetRestaurantDetails()
        {
            var restaurant = _restaurantRepository.GetAll().FirstOrDefault();

            if(restaurant == null)
            {
                throw new Exception("Restaurant not found!");
            }

            var restaurantViewModel = new RestaurantViewModel();
            restaurantViewModel.Id = restaurant.Id;
            restaurantViewModel.Name = restaurant.Name;
            restaurantViewModel.Menu = new List<MenuItemViewModel>();


            foreach(var restaurnatMenuItem in restaurant.Menu)
            {
                var menuItem = new MenuItemViewModel();
                menuItem.Id = restaurnatMenuItem.Id;
                menuItem.Name = restaurnatMenuItem.Name;
                menuItem.Description = restaurnatMenuItem.Description;
                menuItem.Price = restaurnatMenuItem.Price;

                restaurantViewModel.Menu.Add(menuItem);
            }

            return restaurantViewModel;
        }
    }
}
