using System;
using System.Collections.Generic;

namespace Class08_DbFirstApproach.Models.DomainModels
{
    public partial class OrderItem
    {
        public OrderItem()
        {
            Toppings = new HashSet<Topping>();
        }

        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MenuItemId { get; set; }
        public int Quantity { get; set; }
        public decimal PricePerItem { get; set; }

        public virtual MenuItem MenuItem { get; set; } = null!;
        public virtual Order Order { get; set; } = null!;
        public virtual ICollection<Topping> Toppings { get; set; }
    }
}
