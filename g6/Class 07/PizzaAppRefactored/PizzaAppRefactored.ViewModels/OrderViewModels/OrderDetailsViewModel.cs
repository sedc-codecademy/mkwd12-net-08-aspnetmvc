using PizzaAppRefactored.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.ViewModels.OrderViewModels
{
    public class OrderDetailsViewModel
    {
        public int Id { get; set; }
        public string UserFullName { get; set; }
        public double Price { get; set; }
        public bool IsDelivered { get; set; }
        public PaymentMethodEnum PaymentMethod { get; set; }
        public List<string> PizzaNames { get; set; }
    }
}
