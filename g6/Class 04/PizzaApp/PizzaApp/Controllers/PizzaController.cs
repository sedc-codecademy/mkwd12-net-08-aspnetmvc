using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models.Domain;

namespace PizzaApp.Controllers
{
    //[Route("MyPizza")]   
    public class PizzaController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

        // [Route("Pizzas")]
        //[HttpGet("Pizzas")]
        public IActionResult GetAllPizzas()
        {
            List<Pizza> pizzas = StaticDb.Pizzas;
            return View(pizzas);
        }

        public IActionResult Details (int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Error");
            }

            Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            if(pizza == null)
            {
                return RedirectToAction("Error");
            }

            return View(pizza);
        }

        public IActionResult Error()
        {
            //the search for the Error view (and any other view) goes in the following order:
           // 1. it searches in the specific view folder Pizza for the Error view
           //2. if it does not find a corresponding view in the Pizza folder it will search in the shared folder
           //3. if it does not find a view in the shared folder - it will throw an error
            return View(); 
        }
    }
}
