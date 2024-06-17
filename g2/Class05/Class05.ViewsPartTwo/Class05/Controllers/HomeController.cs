using Class05.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Class05.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(string name)
        {
                return View();
        }


        public IActionResult Test(string name)
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult HtmlHelpers()
        {
            return View();
        }

        public IActionResult TagHelpers()
        {
            return View();
        }

        public IActionResult ViewDataAction()
        {
            // ViewData dictionary
            ViewData["Message"] = "Hello there this is message sent via ViewData!";
            ViewData["Message"] = "Hello there this is another message!";
            ViewData["Student"] = new StudentViewModel();


            // ViewBag
            ViewBag.TrainerName = "Martin";
            ViewBag.Student = new StudentViewModel() { Name = "Frosina"};


            //TempData dictionary
            TempData["FirstName"] = "Martin";
            return RedirectToAction("TempDataAction");
            //return View();
        }

        public IActionResult TempDataAction()
        {
            var firstName = TempData["FirstName"];
            return View();
        }
    }
}
