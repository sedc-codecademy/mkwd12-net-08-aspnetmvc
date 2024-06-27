using Microsoft.EntityFrameworkCore;
using TodoApplication.Domain;

namespace TodoApplication.DataAccess
{
    public class TodoAppDbContext : DbContext
    {
        // =====> Defining database tables
        DbSet<Todo> Todo { get; set; }
        DbSet<Status> Status { get; set; }
        DbSet<Category> Category { get; set; }

        public TodoAppDbContext(DbContextOptions<TodoAppDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // =====> Configure relationships 
            modelBuilder.Entity<Todo>()
                .HasOne(t => t.Status)
                .WithMany()
                .HasForeignKey(t => t.StatusId);
            // One to Many Relation => Each Todo has one Status, each Status can have many Todos

            modelBuilder.Entity<Todo>()
                .HasOne(t => t.Category)
                .WithMany()
                .HasForeignKey(t => t.CategoryId);
            // One to Many Relation => Each Todo has one Category, each Category can have many Todos

            // =====> Data Seed
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Work" },
                new Category { Id = 2, Name = "Home" },
                new Category { Id = 3, Name = "Exercise" },
                new Category { Id = 4, Name = "Hobby" },
                new Category { Id = 5, Name = "Shopping" },
                new Category { Id = 6, Name = "Freetime" },
                new Category { Id = 7, Name = "Homework" }
            );

            modelBuilder.Entity<Status>().HasData(
                new Status() { Id = 1, Name = "In Progress" },
                new Status() { Id = 2, Name = "Completed" }
            );

            modelBuilder.Entity<Todo>().HasData(
                new Todo() { Id = 1, Description = "Read EF Documentation", DueDate = DateTime.Now.AddDays(4), CategoryId = 1, StatusId = 1 },
                new Todo() { Id = 2, Description = "Basketball", DueDate = DateTime.Now.AddDays(-3), CategoryId = 4, StatusId = 2 }
            );

            //modelBuilder.Entity<Todo>().Property(p => p.Description).HasMaxLength(100);

            // =====> More configurations ...

            base.OnModelCreating(modelBuilder);
        }
    }
}
