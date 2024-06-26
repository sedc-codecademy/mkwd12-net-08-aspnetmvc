using DomainModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class PizzaAppDbContext : DbContext
    {
        //public PizzaAppDbContext()
        //{
        //}

        public PizzaAppDbContext(DbContextOptions<PizzaAppDbContext> options) : base(options)
        {
        }

        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<MenuItem> MenuItems { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<Pizza> Pizzas { get; set; }
        public virtual DbSet<PizzaIngredient> PizzaIngredients { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Topping> Toppings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserInfo> UserInfos { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<OrderItem>(entity =>
        //    {
        //        //entity.ToTable("Stavki");

        //        //entity.HasOne(x => x.Order)
        //        //.WithMany(x => x.OrderItems)
        //        //.HasForeignKey(x => x.OrderId)
        //        //.OnDelete(DeleteBehavior.Restrict);

        //        //entity.Property(x => x.PricePerItem).HasColumnType("decimal(18,4)");
        //    });


        //    base.OnModelCreating(modelBuilder);
        //}
    }
}
