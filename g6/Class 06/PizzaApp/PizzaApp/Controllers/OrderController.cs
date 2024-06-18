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

            //we need to send all users as options for the select list so we can have a list of users to choose from
            //we use viewbag because this is extra info that we need to send, apart from our viewModel
            ViewBag.Users = StaticDb.Users.Select(x => new UserOptionViewModel
            {
                Id = x.Id,
                UserFullName = $"{x.Firstname} {x.Lastname}"
            });

            return View(orderDialogViewModel);
        }

        [HttpPost] //we need to specify t hat it is a http post method
        public IActionResult CreateOrderPost(OrderDialogViewModel orderDialogViewModel)
        {
            //validation for user, we have to validate if the user id is an id from an existing user
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderDialogViewModel.UserId);

            if(userDb == null)
            {
                return View("ResourceNotFound");
            }

            //validation for pizza, we have to validate that the pizza name is a name of an existing pizza
            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name.ToLower() == orderDialogViewModel.PizzaName.ToLower());

            if (pizzaDb == null)
            {
                return View("ResourceNotFound");
            }
            //mapping from view model to domain model
            Order newOrder = new Order
            {
                Id = StaticDb.Orders.LastOrDefault().Id + 1,
                IsDelivered = orderDialogViewModel.IsDelivered,
                PaymentMethod = orderDialogViewModel.PaymentMethod,
                Pizza = pizzaDb,
                PizzaId = pizzaDb.Id,
                User = userDb,
                UserId = orderDialogViewModel.UserId //userDb.Id
            };

            StaticDb.Orders.Add(newOrder);

            return RedirectToAction("Index");
        }

        public IActionResult EditOrder(int? id)
        {
            //validation
            if(id == null)
            {
                return View("ResourceNotFound");
            }

            //check if an order with the given id exists in the db
            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }
            
            //when we edit the order, we want our form to have the data that we previously created
            OrderDialogViewModel orderDialogViewModel = new OrderDialogViewModel
            {
                IsDelivered = orderDb.IsDelivered,
                PaymentMethod = orderDb.PaymentMethod,
                UserId = orderDb.UserId,
                PizzaName = orderDb.Pizza.Name,
                Id = orderDb.Id
            };

            //we need to send all users as options for the select list so we can have a list of users to choose from
            //we use viewbag because this is extra info that we need to send, apart from our viewModel
            ViewBag.Users = StaticDb.Users.Select(x => new UserOptionViewModel
            {
                Id = x.Id,
                UserFullName = $"{x.Firstname} {x.Lastname}"
            });

            return View(orderDialogViewModel);
        }

        [HttpPost] //we need to specify t hat it is a http post method
        public IActionResult EditOrderPost(OrderDialogViewModel orderDialogViewModel)
        {
            //validation
            //always check the negative scenarios
            if(orderDialogViewModel == null)
            {
                return View("ResourceNotFound");
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == orderDialogViewModel.Id);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            //validation for user, we have to validate if the user id is an id from an existing user
            User userDb = StaticDb.Users.FirstOrDefault(x => x.Id == orderDialogViewModel.UserId);

            if (userDb == null)
            {
                return View("ResourceNotFound");
            }

            //validation for pizza, we have to validate that the pizza name is a name of an existing pizza
            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Name.ToLower() == orderDialogViewModel.PizzaName.ToLower());

            if (pizzaDb == null)
            {
                return View("ResourceNotFound");
            }

            //take the order from db and for each property update its value
            orderDb.Pizza = pizzaDb;
            orderDb.PizzaId = pizzaDb.Id;
            orderDb.User = userDb;
            orderDb.UserId = userDb.Id;
            orderDb.PaymentMethod = orderDialogViewModel.PaymentMethod;
            orderDb.IsDelivered = orderDialogViewModel.IsDelivered;

            return RedirectToAction("Index");
        }

        public IActionResult DeleteOrder(int? id)
        {
            //validation
            if (id == null)
            {
                return View("ResourceNotFound");
            }

            Order orderDb = StaticDb.Orders.FirstOrDefault(x => x.Id == id);
            if (orderDb == null)
            {
                return View("ResourceNotFound");
            }

            int index = StaticDb.Orders.FindIndex(x => x.Id == id); //this way we can find the index in the orders list of our order (that we want to remove)
            if(index == -1) //the index will be -1 if the order was not found in the list
            {
                return View("ResourceNotFound");
            }
            StaticDb.Orders.RemoveAt(index);
            //StaticDb.Orders.Remove(orderDb);

            return RedirectToAction("Index");
        }
    }
}
