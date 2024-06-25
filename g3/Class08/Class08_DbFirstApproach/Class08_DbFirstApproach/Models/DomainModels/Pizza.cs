using System;
using System.Collections.Generic;

namespace Class08_DbFirstApproach.Models.DomainModels
{
    public partial class Pizza
    {
        public Pizza()
        {
            MenuItems = new HashSet<MenuItem>();
            PizzaIngredients = new HashSet<PizzaIngredient>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
        public virtual ICollection<PizzaIngredient> PizzaIngredients { get; set; }
    }
}
