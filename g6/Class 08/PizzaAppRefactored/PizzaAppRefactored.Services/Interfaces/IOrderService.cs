using PizzaAppRefactored.ViewModels.OrderViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.Services.Interfaces
{
    public interface IOrderService
    {
        List<OrderDetailsViewModel> GetAllOrders();

        OrderDetailsViewModel GetOrderById(int id);

        void CreateOrder(OrderDialogViewModel orderDialogViewModel);
    }
}
