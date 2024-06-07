using Microsoft.AspNetCore.Mvc;
using Services.Implementation;
using Services.Interfaces;

namespace BbqApp.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController()
        {
            _restaurantService = new RestaurantService();
        }

        public IActionResult Index()
        {
            var result = _restaurantService.GetRestaurantDetails();
            return View(result);
        }
    }
}
