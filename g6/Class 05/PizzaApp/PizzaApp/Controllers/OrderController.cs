using Microsoft.AspNetCore.Mvc;
using PizzaApp.Models.Domain;
using PizzaApp.Models.Mappers;
using PizzaApp.Models.ViewModels;

namespace PizzaApp.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            List<Order> ordersFromDb = StaticDb.Orders;
            List<OrderDetailsViewModel> orderDetailsViewModelList = new List<OrderDetailsViewModel>();
            foreach(Order order in ordersFromDb)
            {
                //Pizza pizza = StaticDb.Pizzas.FirstOrDefault(x => x.Id == order.PizzaId);

                //OrderDetailsViewModel viewModel = new OrderDetailsViewModel
                //{
                //    PaymentMethod = order.PaymentMethod,
                //    // PizzaName = pizza.Name,
                //    PizzaName = order.Pizza.Name, //because we have the pizza object in StaticDb we can access it this way
                //    Price = order.Pizza.Price + 50,
                //    UserFullName = order.User.Firstname + "  " + order.User.Lastname
                //};

                OrderDetailsViewModel viewModel = OrderMapper.ToOrderDetailsViewModel(order);

                orderDetailsViewModelList.Add(viewModel);
            }
            //we use view data to send extra data that we want to show in our view
            ViewData["Title"] = "These are the orders made with our app:";
            ViewData["NumberOfOrders"] = StaticDb.Orders.Count;
            return View(orderDetailsViewModelList);
        }

        public IActionResult Details(int? id)
        {
            if(id == null)
            {
                return new EmptyResult();
            }

            Order order = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (order == null)
            {
                // return new EmptyResult();
                return View("ResourceNotFound");
            }

            //OrderDetailsViewModel viewModel = new OrderDetailsViewModel
            //{
            //    PaymentMethod = order.PaymentMethod,
            //    PizzaName = order.Pizza.Name, //because we have the pizza object in StaticDb we can access it this way
            //    Price = order.Pizza.Price + 50,
            //    UserFullName = order.User.Firstname + "  " + order.User.Lastname
            //};
            OrderDetailsViewModel viewModel = OrderMapper.ToOrderDetailsViewModel(order);

            ViewBag.Title = $"Details for order with id {id}";
            ViewBag.User = order.User;
            return View(viewModel); //here we are sending to the view only the data that needs to be shown to the user in the view

        }

        //[HttpGet]
        public IActionResult CreateOrder()
        {
            OrderDialogViewModel orderDialogViewModel = new OrderDialogViewModel();

            ViewBag.Users = StaticDb.Users.Select(x => new UserOptionViewModel
            {
                Id = x.Id,
                UserFullName = $"{x.Firstname} {x.Lastname}"
            });

            return View(orderDialogViewModel);
        }
    }
}
