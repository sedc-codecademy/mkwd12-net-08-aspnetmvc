using PizzaApp.Models.Domain;

namespace PizzaApp
{
    public static class StaticDb
    {
        public static List<Pizza> Pizzas = new List<Pizza> {
        new Pizza()
        {
            Id = 1,
            Name = "Capricciosa",
            Price = 300,
            IsOnPromotion = true,
        },
        new Pizza()
        {
            Id =2,
            Name = "Pepperoni",
            Price = 350,
            IsOnPromotion = false
        }
        };

        public static List<User> Users = new List<User>
        {
            new User
            {
                Id =1,
                Firstname = "Tijana",
                Lastname = "Stojanovska",
                PhoneNumber = "070123456"
            },
            new User
            {
                Id =2,
                Firstname ="Roze",
                Lastname = "Dobrinova",
                PhoneNumber = "070678987"
            }
        };
        public static List<Order> Orders = new List<Order>
        {
          new Order {
              Id =1,
              PizzaId = 1,
              Pizza = Pizzas.FirstOrDefault(x => x.Id == 1), //it searches the pizzasList by pizzaId, which is 1
              UserId = 1,
              User = Users.FirstOrDefault(x => x.Id == 1), //it searches the usersList by userId, which is 1
              PaymentMethod = Models.Enums.PaymentMethodEnum.Cash
          },
           new Order {
              Id =2,
              PizzaId = 2,
              Pizza = Pizzas.FirstOrDefault(x => x.Id == 2),
              UserId = 2,
              User = Users.FirstOrDefault(x => x.Id == 2),
              PaymentMethod = Models.Enums.PaymentMethodEnum.Card
          }
        };
    }

}


