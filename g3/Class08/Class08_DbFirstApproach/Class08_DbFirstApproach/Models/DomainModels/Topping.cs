using System;
using System.Collections.Generic;

namespace Class08_DbFirstApproach.Models.DomainModels
{
    public partial class Topping
    {
        public int Id { get; set; }
        public int OrderItemId { get; set; }
        public int IngredientId { get; set; }
        public decimal PricePerItem { get; set; }

        public virtual Ingredient Ingredient { get; set; } = null!;
        public virtual OrderItem OrderItem { get; set; } = null!;
    }
}
