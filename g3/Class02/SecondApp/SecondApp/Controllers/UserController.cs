using Microsoft.AspNetCore.Mvc;

namespace SecondApp.Controllers
{
    public class UserController : Controller
    {
        [Route("[Controller]/[Action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("[Controller]/[Action]/{id}")]
        public IActionResult Index(int id)
        {
            return View(id);
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult PlainText()
        {
            return Content("This is plain text!");
        }

        public IActionResult JsonAction()
        {
            List<KeyValuePair<int, string>> names = new List<KeyValuePair<int, string>> {
              new KeyValuePair<int, string>(1, "Risto"),
              new KeyValuePair<int, string>(2, "Slave"),
              new KeyValuePair<int, string>(3, "Dimitar")
            };

            return Json(names);
        }
    }
}
