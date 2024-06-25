namespace DomainModels
{
    public class PizzaIngredient : BaseEntity
    {
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public bool Mandatory { get; set; }
    }
}
