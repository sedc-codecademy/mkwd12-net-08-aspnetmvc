using Microsoft.AspNetCore.Mvc;
using Services.Implementation;
using Services.Interfaces;

namespace PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaService _pizzaService;

        public PizzaController()
        {
            _pizzaService = new PizzaService();
        }

        public IActionResult Index()
        {
            var items = _pizzaService.GetAll();
            return View(items);
        }

        public IActionResult Details(int id)
        {
            var item = _pizzaService.GetDetails(id);
            return View(item);
        }

        public IActionResult SearchByName(string name)
        {
            return View();
        }
    }
}
