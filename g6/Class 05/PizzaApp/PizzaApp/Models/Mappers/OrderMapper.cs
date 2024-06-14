using PizzaApp.Models.Domain;
using PizzaApp.Models.ViewModels;

namespace PizzaApp.Models.Mappers
{
    public static class OrderMapper
    {
        public static OrderDetailsViewModel ToOrderDetailsViewModel(Order order)
        {
            return new OrderDetailsViewModel
            {
                PaymentMethod = order.PaymentMethod,
                PizzaName = order.Pizza.Name,
                Price = order.Pizza.Price + 50,
                UserFullName = order.User.Firstname + "  " + order.User.Lastname
            };
        }
    }
}
