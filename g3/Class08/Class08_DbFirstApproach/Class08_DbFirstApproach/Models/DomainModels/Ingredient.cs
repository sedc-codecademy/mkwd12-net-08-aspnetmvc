using System;
using System.Collections.Generic;

namespace Class08_DbFirstApproach.Models.DomainModels
{
    public partial class Ingredient
    {
        public Ingredient()
        {
            PizzaIngredients = new HashSet<PizzaIngredient>();
            Toppings = new HashSet<Topping>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<PizzaIngredient> PizzaIngredients { get; set; }
        public virtual ICollection<Topping> Toppings { get; set; }
    }
}
