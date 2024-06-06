using Microsoft.AspNetCore.Mvc;

namespace Class02.Controllers
{
    public class HomeController : Controller
    {

        #region Actions that returns ViewResult()
        // Index() is Action in HomeController that returns ViewResult()
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        #endregion

        #region Actions that returns Content() or any other type of result
        public IActionResult SomeContent()
        {
            return Content("Hello there! This is some content sent!");
            //return Content("<p>Hello there! This is some content sent!</p>");
        }

        public string SayHello()
        {
            return "Hello there! We are learning MVC!";
        }

        public int GetNumber()
        {
            var random = new Random();
            int result = random.Next(1, 10);

            return result;
        }
        #endregion

        #region EmptyResult
        public IActionResult EmptyAction()
        {
            return new EmptyResult();
        }

        #endregion

        #region Actions that returns RedirectToAction() result

        public IActionResult DisplayNumber(int? id)
        {
            if (id.HasValue)
                return View();
            return RedirectToAction("Error");
            //return RedirectToAction("Error", "Home");
        }

        public IActionResult Error()
        {
            return View();
        }


        #endregion

        public IActionResult GetUserData()
        {
            var user = new { Id = 1, FullName = "Martin Panovski", Role = "Trainer" };
            return new JsonResult(user);
        }
    }
}
