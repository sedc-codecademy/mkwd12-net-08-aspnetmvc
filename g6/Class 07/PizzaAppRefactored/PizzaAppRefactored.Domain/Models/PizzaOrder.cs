using PizzaAppRefactored.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.Domain.Models
{
    public  class PizzaOrder : BaseEntity
    {
        public Pizza Pizza { get; set; }
        public int PizzaId { get; set; }

        public Order Order { get; set; }
        public int OrderId { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public PizzaSizeEnum PizzaSize {  get; set; }
    }
}
