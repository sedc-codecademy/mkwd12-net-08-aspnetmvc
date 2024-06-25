namespace DomainModels
{
    public class MenuItem : BaseEntity
    {
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int SizeId { get; set; }
        public Size Size { get; set; }
        public decimal Price { get; set; }
    }
}
