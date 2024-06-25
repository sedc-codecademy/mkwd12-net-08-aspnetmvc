using Microsoft.AspNetCore.Mvc;
using TodoApplication.Dtos.Dto;
using TodoApplication.Dtos.ViewModel;
using TodoApplication.Services;
using TodoApplication.Services.Interfaces;

namespace TodoApplication.WebApp.Controllers
{
    [Route("")]
    public class TodoController : Controller
    {
        private FilterService _filterService;
        //private TodoService _todoService;
        private ITodoService _todoService;

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

            ViewBag.Filter = new FilterDto();

            if (TempData["HasFilter"] != null)
            {
                ViewBag.Filter.CategoryId = (int)TempData["Category"];
                categoryId = (int)TempData["Category"];
                ViewBag.Filter.StatusId = (int)TempData["Status"];
                statusId = (int)TempData["Status"];
            }

            ViewBag.Filter.Categories = _filterService.GetCategories();
            ViewBag.Filter.Statuses = _filterService.GetStatuses();

            var todos = _todoService.GetTodos(categoryId, statusId);
            return View(todos);
        }

        [HttpPost("filter")]
        public IActionResult Filter(FilterVM filterVM)
        {
            TempData["HasFilter"] = true;
            TempData["Category"] = filterVM.CategoryId;
            TempData["Status"] = filterVM.StatusId;

            return RedirectToAction(nameof(Index));
        }
    }
}
