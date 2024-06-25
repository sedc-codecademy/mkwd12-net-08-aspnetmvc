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

        [HttpPost("mark-complete")]
        public IActionResult MarkComplete(int id)
        {
            var todoMarkComplete = _todoService.MarkComplete(id);
            if (!todoMarkComplete)
            {
                TempData["ErrorMessage"] = "Todo does not exists";
            }

            return RedirectToAction("Index");
        }

        [HttpPost("remove-complete")]
        public IActionResult RemoveComplete()
        {
            _todoService.RemoveComplete();
            return RedirectToAction("Index");
        }

        [HttpGet("add")]
        public IActionResult AddTodo()
        {
            ViewBag.Categories = _filterService.GetCategories();
            return View("AddTodo");
        }

        [HttpPost("add")]
        public IActionResult AddTodo(CreateTodoVM createTodoVM)
        {
            if(createTodoVM.CategoryId == 0)
            {
                ViewBag.Error = "Please select valid category";
                ViewBag.Categories = _filterService.GetCategories();
                return View(createTodoVM);
            }
            
            _todoService.AddTodo(createTodoVM);
            return RedirectToAction("Index");
        }
    }
}
