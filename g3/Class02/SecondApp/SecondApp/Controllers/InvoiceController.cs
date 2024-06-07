using Microsoft.AspNetCore.Mvc;

namespace SecondApp.Controllers
{
    [Route("fakturi/v1")]
    public class InvoiceController : Controller
    {
        [Route("[Action]")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("detali")]
        public IActionResult Details(int id)
        {
            return View();
        }
    }
}
