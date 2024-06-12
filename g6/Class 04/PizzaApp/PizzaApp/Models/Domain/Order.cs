using PizzaApp.Models.Enums;

namespace PizzaApp.Models.Domain
{
    public class Order
    {
        public int Id { get; set; }
        public int PizzaId { get; set; }

        public Pizza Pizza { get; set;} //we use it to create the joins

        public int UserId { get; set; }

        public User User { get; set; } //we use it to create the joins

        public PaymentMethodEnum PaymentMethod { get; set; }

    }
}
