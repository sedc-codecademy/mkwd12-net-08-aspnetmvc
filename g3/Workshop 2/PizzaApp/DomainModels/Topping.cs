namespace DomainModels
{
    public class Topping : BaseEntity
    {
        public int OrderItemId { get; set; }
        public OrderItem OrderItem { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public decimal PricePerItem { get; set; }
    }
}
