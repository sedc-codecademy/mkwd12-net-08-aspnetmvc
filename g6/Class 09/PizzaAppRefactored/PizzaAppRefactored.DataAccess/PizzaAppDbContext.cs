using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Abstractions;
using PizzaAppRefactored.Domain.Models;

namespace PizzaAppRefactored.DataAccess
{
    //context class has to inherit from DBContext
    public class PizzaAppDbContext : DbContext
    {
        //through the options param we get different info for the configuration of the db connection
        public PizzaAppDbContext(DbContextOptions options) : base(options) { }

        //define main tables (domain classes that you want to map into tables)
        //you don't need to spcify the tables for the many-to-many relationship
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<User> Users { get; set; }

        //defining relations, eventaully adding inital data in the db (seeding)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //define relations
            modelBuilder.Entity<Pizza>() //the main table
                .HasMany(x => x.PizzaOrders) //one pizza is related with many records in the PizzaOrder table
                .WithOne(x => x.Pizza) //one PizzaOrder is related to one record in the Pizza table
                .HasForeignKey(x => x.PizzaId);

            modelBuilder.Entity<Order>()
                .HasMany(x => x.PizzaOrders)
                .WithOne(x => x.Order)
                .HasForeignKey(x => x.OrderId);

            //modelBuilder.Entity<Order>()
            //    .HasOne(x => x.User)//one order is related to one record in the user table
            //    .WithMany(x => x.Orders) //one user can be related to many records in the Orders table
            //    .HasForeignKey(x => x.UserId);

            modelBuilder.Entity<User>()
                .HasMany(x => x.Orders) //1-m relationship (many side)
                .WithOne(x => x.User) //1-m relationship (one side)
                .HasForeignKey(x => x.UserId); //the foreign key in the relationship

            //SEEDING
            modelBuilder.Entity<Pizza>()
                .HasData(new Pizza  //with has data we can add initial data in the db
                {
                    Id = 1,
                    Name = "Capricciosa",
                    IsOnPromotion = true
                },
                new Pizza
                {
                    Id = 2,
                    Name = "Pepperoni",
                    IsOnPromotion = false
                }
                );

            modelBuilder.Entity<User>()
                .HasData(new User  //with has data we can add initial data in the db
                {
                    Id = 1,
                    Firstname = "Tijana",
                    Lastname = "Stojanovska",
                    Address = "Address1"
                },
                new User
                {
                    Id = 2,
                    Firstname = "Roze",
                    Lastname = "Dobrinova",
                    Address = "Address2"
                }
                );

            modelBuilder.Entity<Order>()
                .HasData(new Order  //with has data we can add initial data in the db
                {
                    Id = 1,
                    PizzaStore = "Jakomo",
                    IsDelivered = false,
                    PaymentMethod = Domain.Enums.PaymentMethodEnum.Cash,
                    UserId = 1
                },
                new Order
                {
                    Id = 2,
                    PizzaStore = "Dominos",
                    IsDelivered = false,
                    PaymentMethod = Domain.Enums.PaymentMethodEnum.Card,
                    UserId = 2
                }
                );
            modelBuilder.Entity<PizzaOrder>()
                .HasData(new PizzaOrder  //with has data we can add initial data in the db
                {
                    Id = 1,
                    PizzaId = 1,
                    Price = 350,
                    Quantity = 1,
                    OrderId = 2,
                    PizzaSize = Domain.Enums.PizzaSizeEnum.Standard
                },
                new PizzaOrder
                {
                    Id = 2,
                    PizzaId = 2,
                    Price = 400,
                    Quantity = 2,
                    OrderId = 1,
                    PizzaSize = Domain.Enums.PizzaSizeEnum.Medium
                }
                );
        }
    }
}
