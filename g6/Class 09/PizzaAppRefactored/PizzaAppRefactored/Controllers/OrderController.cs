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
        public IPizzaService _pizzaService;

        public OrderController(IOrderService orderService, IUserService userService, IPizzaService pizzaService)
        {
            _orderService = orderService;
            _userService = userService;
            _pizzaService = pizzaService;
        }
        public IActionResult Index()
        {
            List <OrderDetailsViewModel> orderDetailsViewModels = _orderService.GetAllOrders();
            return View(orderDetailsViewModels);
        }

        public IActionResult Details(int? id)
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

        public IActionResult AddPizza(int id)
        {
            AddPizzaToOrderViewModel addPizzaToOrderViewModel = new AddPizzaToOrderViewModel();
            addPizzaToOrderViewModel.OrderId = id;

            ViewBag.Pizzas = _pizzaService.GetAllPizzasForDropdown();

            return View(addPizzaToOrderViewModel);
        }

        [HttpPost]
        public IActionResult AddPizzaPost(AddPizzaToOrderViewModel addPizzaToOrderViewModel)
        {
            try
            {
                _orderService.AddPizzaToOrder(addPizzaToOrderViewModel);
                return RedirectToAction("Details", new {id = addPizzaToOrderViewModel.OrderId});
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GeneralError");
            }
        }

        public IActionResult DeleteOrder(int? id)
        {
            if(id == null)
            {
                return View("BadRequest");
            }
            try
            {
                OrderDetailsViewModel orderDetailsViewModel = _orderService.GetOrderById(id.Value);
                return View(orderDetailsViewModel);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("GeneralError");
            }
        }

        public IActionResult ConfirmDelete(int? id)
        {
            if (id == null)
            {
                return View("BadRequest");
            }
            try
            {
                _orderService.DeleteOrder(id.Value);
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
