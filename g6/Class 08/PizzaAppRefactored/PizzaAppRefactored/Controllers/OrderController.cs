using Microsoft.AspNetCore.Mvc;
using PizzaAppRefactored.Services.Interfaces;
using PizzaAppRefactored.ViewModels.OrderViewModels;
using System.Reflection.Metadata.Ecma335;



namespace PizzaAppRefactored.Controllers
{
    public class OrderController : Controller
    {
        public IOrderService _orderService;
        public IUserService _userService;

        public OrderController(IOrderService orderService, IUserService userService)
        {
            _orderService = orderService;
            _userService = userService; 
        }
        public IActionResult Index()
        {
            List <OrderDetailsViewModel> orderDetailsViewModels = _orderService.GetAllOrders();
            return View(orderDetailsViewModels);
        }

        public IActionResult Details([FromRoute] int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }
            try
            {                                           //to get the value from the id (bacause it is nullable) we use .value
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderById(id.Value);
                return View(orderDetailsViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GeneralError");
            }
        }

        public IActionResult CreateOrder()
        {
            OrderDialogViewModel orderDialogViewModel = new OrderDialogViewModel();

            ViewBag.Users = _userService.GetAllUsersForDropdown();
            
            return View(orderDialogViewModel);
        }

        [HttpPost]

        public IActionResult CreateOrder([FromForm] OrderDialogViewModel orderDialogViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    ViewBag.Users = _userService.GetAllUsersForDropdown();
                    //when we return this view, the error message will be shown
                    return View(orderDialogViewModel); //return the view again with the invalid model that was sent to us on create
                }

                _orderService.CreateOrder(orderDialogViewModel);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GeneralError");
            }
        }

    }
}
