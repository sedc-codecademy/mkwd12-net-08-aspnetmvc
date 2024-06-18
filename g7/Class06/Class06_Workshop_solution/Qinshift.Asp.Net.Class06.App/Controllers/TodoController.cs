using Microsoft.AspNetCore.Mvc;
using Qinshift.Asp.Net.Class06.App.Models.Dtos;
using Qinshift.Asp.Net.Class06.App.Models.ViewModels;
using Qinshift.Asp.Net.Class06.App.Services;
using System.Linq;

namespace Qinshift.Asp.Net.Class06.App.Controllers
{
    [Route("")]
    public class TodoController : Controller
    {
        private FiltersService _filtersService;
        private TodoService _todoService;

        public TodoController()
        {
            _filtersService = new FiltersService();
            _todoService = new TodoService();
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            int? categoryId = null;
            int? statusId = null;

            ViewBag.Filter = new FilterDto();
            if (TempData["HasFilter"] != null && (bool)TempData["HasFilter"])
            {
                ViewBag.Filter.CategoryId = (int)TempData["Category"];
                categoryId = (int)TempData["Category"];
                ViewBag.Filter.StatusId = (int)TempData["Status"];
                statusId = (int)TempData["Status"];
            }
            ViewBag.Filter.Categories = _filtersService.GetCategories();
            ViewBag.Filter.Statuses = _filtersService.GetStatuses();

            if (TempData["ErrorMessage"] != null)
            {
                ViewBag.Error = (string)TempData["ErrorMessage"];
            }

            var todos = _todoService.GetTodos(categoryId, statusId);
            return View(todos);
        }

        [HttpPost("filter")]
        public IActionResult Filter(FilterVM filter) 
        {
            TempData["HasFilter"] = true;
            TempData["Category"] = filter.CategoryId;
            TempData["Status"] = filter.StatusId;
            ViewBag.ActiveFilter = filter;
            //TempData["DueDate"] = filter.DueDate;
            return RedirectToAction(nameof(Index));
        }

        [HttpPost("mark-complete")]
        public IActionResult MarkComplete(int id)
        {
            var response = _todoService.MarkComplete(id);
            if(!response)
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
            ViewBag.Categories = _filtersService.GetCategories();
            return View("AddTodo");
        }


        [HttpPost("add")]
        public IActionResult AddTodo(CreateTodoVM todo)
        {
            if (todo.CategoryId == 0)
            {
                ViewBag.Error = "Please select valid category";
                ViewBag.Categories = _filtersService.GetCategories();
                return View(todo);
            }

            _todoService.AddTodo(todo);
            return RedirectToAction("Index");
        }
    }
}
