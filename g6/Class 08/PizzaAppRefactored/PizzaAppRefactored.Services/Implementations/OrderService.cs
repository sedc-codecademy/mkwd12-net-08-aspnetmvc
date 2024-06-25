using PizzaAppRefactored.DataAccess;
using PizzaAppRefactored.Domain.Models;
using PizzaAppRefactored.Mappers;
using PizzaAppRefactored.Services.Interfaces;
using PizzaAppRefactored.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.Services.Implementations
{
    public class OrderService : IOrderService
    {
        //we use the interface of the repositories that we need
        private IRepository<Order> _orderRepository;
        private IRepository<User> _userRepository;

        public OrderService(IRepository<Order> orderRepository,
                            IRepository<User> userRepository)
        {
            _orderRepository = orderRepository;
            _userRepository = userRepository;
        }

        public void CreateOrder(OrderDialogViewModel orderDialogViewModel)
        {
           //validation
           if(orderDialogViewModel == null)
            {
                throw new Exception("Model cannot be null");
            }

            User user = _userRepository.GetById(orderDialogViewModel.UserId);
            if(user == null)
            {
                throw new Exception($"User with id {orderDialogViewModel.UserId} was not found");
            }

            //mapping
            Order newOrder = OrderMapper.ToOrder(orderDialogViewModel);
            newOrder.User = user;

            //send it to repo which will send it to db
            int newOrderId = _orderRepository.Insert(newOrder);
            if(newOrderId <= 0)
            {
                throw new Exception("An error occured while adding the new order");
            }
        }

        public List<OrderDetailsViewModel> GetAllOrders()
        {
            List<Order> ordersFromDb = _orderRepository.GetAll();

            List<OrderDetailsViewModel> orderDetailsViewModelList = new List<OrderDetailsViewModel>();
            foreach (Order order in ordersFromDb)
            {
                OrderDetailsViewModel viewModel = OrderMapper.ToOrderDetailsViewModel(order);

                orderDetailsViewModelList.Add(viewModel);
            }

            return orderDetailsViewModelList;
        }

        public OrderDetailsViewModel GetOrderById(int id)
        {
            //get the order from repo who will get it from the db
            Order orderDb = _orderRepository.GetById(id);

            //validation
            if(orderDb == null)
            {
                throw new Exception($"The order with id {id} was not found");
            }

            //Mapping the domain to view model
            OrderDetailsViewModel viewModel = OrderMapper.ToOrderDetailsViewModel(orderDb);
            return viewModel;
        }
    }
}
