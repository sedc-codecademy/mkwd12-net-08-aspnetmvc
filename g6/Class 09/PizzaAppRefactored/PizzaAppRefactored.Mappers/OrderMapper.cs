using PizzaAppRefactored.Domain.Models;
using PizzaAppRefactored.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.Mappers
{
    public static class OrderMapper
    {
        public static OrderDetailsViewModel ToOrderDetailsViewModel(Order order)
        {
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                IsDelivered = order.IsDelivered,
                PaymentMethod = order.PaymentMethod,
                UserFullName = $"{order.User.Firstname} {order.User.Lastname}",
                Price = order.PizzaOrders.Sum(x => x.Price),
                PizzaNames = order.PizzaOrders.Select(x => x.Pizza.Name).ToList()
            };
        }

        public static Order ToOrder(OrderDialogViewModel orderDialogViewModel)
        {
            return new Order
            {
                IsDelivered = orderDialogViewModel.IsDelivered,
                PaymentMethod = orderDialogViewModel.PaymentMethod,
                PizzaStore = orderDialogViewModel.PizzaStore,
                UserId = orderDialogViewModel.UserId,
                PizzaOrders = new List<PizzaOrder>()
            };
        }
    }

}