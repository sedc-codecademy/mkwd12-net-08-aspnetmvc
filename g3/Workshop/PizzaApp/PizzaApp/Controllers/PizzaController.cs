using Microsoft.AspNetCore.Mvc;
using Services.Implementation;
using Services.Interfaces;
using ViewModels;

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

        //CASE 1:
        //public IActionResult SearchByName(string id)
        //{
        //    var items = _pizzaService.SearchByName(id);
        //    return View("Index", items);
        //}

        //CASE 2:
        //public IActionResult SearchByName(string id)
        //{
        //    var items = _pizzaService.SearchByName(id);
        //    return Json(items);
        //}

        //CASE 3:
        //[HttpPost]
        //public IActionResult SearchByName([FromBody] FilterViewModel model)
        //{
        //    var items = _pizzaService.SearchByName(model.Name);
        //    return Json(items);
        //}

        //CASE 4:
        [HttpPost]
        public IActionResult SearchByName([FromForm] FilterViewModel filterModel)
        {
            var items = _pizzaService.SearchByName(filterModel.Name);
            return View("Index", items);
        }
    }
}
