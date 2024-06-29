using Microsoft.AspNetCore.Mvc;
using Services.Implementation;
using Services.Interfaces;
using ViewModels;

namespace PizzaApp.Controllers
{
    public class PizzaController : Controller
    {
        private IPizzaService _pizzaService;

        public PizzaController(IPizzaService pizzaService)
        {
            _pizzaService = pizzaService;
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

        public IActionResult Create()
        {
            var pizza = new PizzaViewModel();
            var types = _pizzaService.GetTypeOptions();
            ViewBag.Types = types;

            return View(pizza);
        }

        [HttpPost]
        public IActionResult Create([FromForm] PizzaViewModel model)
        {
            if(!ModelState.IsValid)
            {
                var types = _pizzaService.GetTypeOptions();
                ViewBag.Types = types;
                return View(model);
            }

            _pizzaService.Create(model);


            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var pizza = _pizzaService.GetDetails(id);
            var types = _pizzaService.GetTypeOptions();
            ViewData["Types"] = types;
            return View(pizza);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] PizzaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var types = _pizzaService.GetTypeOptions();
                ViewData["Types"] = types;
                return View(model);
            }

            _pizzaService.Update(model);


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _pizzaService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
