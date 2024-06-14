using Class05.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Class05.Controllers
{
    [Route("home")]
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
