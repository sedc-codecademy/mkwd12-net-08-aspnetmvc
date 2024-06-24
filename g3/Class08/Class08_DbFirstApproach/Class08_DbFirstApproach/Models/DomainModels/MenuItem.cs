using System;
using System.Collections.Generic;

namespace Class08_DbFirstApproach.Models.DomainModels
{
    public partial class MenuItem
    {
        public MenuItem()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int SizeId { get; set; }
        public decimal Price { get; set; }

        public virtual Pizza Pizza { get; set; } = null!;
        public virtual Size Size { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
