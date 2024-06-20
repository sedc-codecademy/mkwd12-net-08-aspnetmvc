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

        public OrderService(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
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
    }
}
