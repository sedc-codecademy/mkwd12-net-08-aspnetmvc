using Microsoft.AspNetCore.Mvc;
using TodoApplication.Services;

namespace TodoApplication.WebApp.Controllers
{
    [Route("")]
    public class TodoController : Controller
    {
        private FilterService _filterService;
        private TodoService _todoService;

        public TodoController()
        {
            _filterService = new FilterService();
            _todoService = new TodoService();
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            int? categoryId = null;
            int? statusId = null;

            var todos = _todoService.GetTodos(categoryId, statusId);
            return View(todos);
        }
    }
}
