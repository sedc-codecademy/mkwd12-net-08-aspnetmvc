using PizzaAppRefactored.Domain.Enums;
using PizzaAppRefactored.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaAppRefactored.DataAccess
{
    public static class StaticDb
    {
        public static List<Pizza> Pizzas = new List<Pizza>
        {
            new Pizza()
            {
                Id = 1,
                Name = "Capricciosa",
                IsOnPromotion = true,
                PizzaOrders = new List<PizzaOrder>
                {

                }
            },
            new Pizza()
            {
                Id = 2,
                Name = "Pepperoni",
                IsOnPromotion = false,
                PizzaOrders = new List<PizzaOrder>
                {

                }
            }

        };


        public static List<User> Users = new List<User>  {

            new User
            {
                Id = 1,
                Firstname ="Tijana",
                Lastname = "Stojanovska",
                Address = "Address1",
                Orders = new List<Order>
                {

                }
            },

            new User
            {
                Id = 2,
                Firstname ="Roze",
                Lastname = "Dobrinova",
                Address = "Address2",
                Orders = new List<Order>
                {

                }
            }

            };


        public static List<Order> Orders = new List<Order> {

            new Order
            {
                Id = 1,
                PizzaStore = "Jakomo",
                IsDelivered = false,
                PaymentMethod = PaymentMethodEnum.Card,
                PizzaOrders = new List<PizzaOrder>
                {
                    new PizzaOrder
                    {
                        Id = 1,
                        Pizza = Pizzas[0],
                        PizzaId = Pizzas[0].Id,
                        Price = 300,
                        Quantity = 1,
                        OrderId = 1,
                        PizzaSize = PizzaSizeEnum.Standard
                    },

                    new PizzaOrder
                    {
                        Id = 2,
                        Pizza = Pizzas[1],
                        PizzaId = Pizzas[1].Id,
                        Price = 600,
                        Quantity = 2,
                        OrderId = 1,
                        PizzaSize = PizzaSizeEnum.Family
                    },

                },
                UserId = Users[0].Id,
                User = Users[0]

            },

            new Order
            {
                Id = 2,
                PizzaStore = "Dominos",
                IsDelivered = false,
                PaymentMethod = PaymentMethodEnum.Cash,
                PizzaOrders = new List<PizzaOrder>
                {
                    new PizzaOrder
                    {
                        Id = 3,
                        Pizza = Pizzas[1],
                        PizzaId = Pizzas[1].Id,
                        Price = 350,
                        Quantity = 1,
                        OrderId = 2,
                        PizzaSize = PizzaSizeEnum.Standard
                    },

                },
                UserId = Users[1].Id,
                User = Users[1]

            }

        };
    }
}
