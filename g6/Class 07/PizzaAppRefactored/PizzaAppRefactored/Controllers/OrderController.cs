using Microsoft.AspNetCore.Mvc;
using PizzaAppRefactored.Services.Interfaces;
using PizzaAppRefactored.ViewModels.OrderViewModels;



namespace PizzaAppRefactored.Controllers
{
    public class OrderController : Controller
    {
        public IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public IActionResult Index()
        {
            List <OrderDetailsViewModel> orderDetailsViewModels = _orderService.GetAllOrders();
            return View(orderDetailsViewModels);
        }
    }
}
