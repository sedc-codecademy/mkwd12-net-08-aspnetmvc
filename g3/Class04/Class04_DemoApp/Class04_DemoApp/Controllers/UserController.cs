using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace Class04_DemoApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            var result = StaticDb.Users;
            return View(result);
        }

        public IActionResult Details(int id)
        {
            var result = StaticDb.Users.FirstOrDefault(x => x.Id == id);

            if (result == null)
            {
                return View("NoUserView");
            }

            return View(result);
        }
    }
}
