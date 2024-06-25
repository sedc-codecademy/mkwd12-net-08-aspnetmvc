using System;
using System.Collections.Generic;

namespace Class08_DbFirstApproach.Models.DomainModels
{
    public partial class PizzaIngredient
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }
        public int IngredientId { get; set; }
        public bool Mandatory { get; set; }

        public virtual Ingredient Ingredient { get; set; } = null!;
        public virtual Pizza Pizza { get; set; } = null!;
    }
}
