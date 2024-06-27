using PizzaAppRefactored.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.Domain.Models
{
    public class Order : BaseEntity
    {
        public int UserId { get; set; }

        public User User { get; set; } //we use it to create the joins

        public PaymentMethodEnum PaymentMethod { get; set; }

        public bool IsDelivered { get; set; }

        public string PizzaStore {  get; set; }

        public List<PizzaOrder> PizzaOrders { get; set;}
    }
}
