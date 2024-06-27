using Class09_EF.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Class09_EF.DataAccess
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options) { }

        //this will create and manage Students table in our database
        public DbSet<Student> Students { get; set; }
        //this will create and manage Course table in our database
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region

            //FluentAPI
            modelBuilder.Entity<Student>(entity =>
            {
                //defining primary key for students table =>
                entity.HasKey(q => q.Id);

                entity.Property(e => e.FirstName)
                      .HasMaxLength(50)
                      //.IsRequired(false) // this will make prop nullable
                      .IsRequired(); 
            });

            #endregion

            #region comments

            //commands:
            //1. add-migration => creates a representation of our db context and its making it ready for
            //applying to our database

            //2. update-database => in fact this command actually updates the sql database with the
            // new db context applying with the latest migration

            #endregion

            #region seeding the Db

            var courses = new List<Course>()
            {
                new() {Id = 1, Name = "C# basic", NumberOfClasses = 40},
                new() {Id = 2, Name = "C# advanced", NumberOfClasses = 60},
                new() {Id = 3, Name = "Database development and design", NumberOfClasses = 28},
                new() {Id = 4, Name = "ASP.NET MVC", NumberOfClasses = 40}
            };

            var student = new List<Student>
            {
                new Student()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobski",
                    DateOfBirth = DateTime.Now.AddYears(-25),
                    ActiveCourseId = 4
                },
                new Student()
                {
                    Id = 2,
                    FirstName = "John",
                    LastName = "Doe",
                    DateOfBirth = DateTime.Now.AddYears(-23),
                    ActiveCourseId = 3
                },
                new Student()
                {
                    Id = 3,
                    FirstName = "Todor",
                    LastName = "Pelivanov",
                    DateOfBirth = DateTime.Now.AddYears(-18),
                    ActiveCourseId = 2
                },
                new Student()
                {
                    Id = 4,
                    FirstName = "Ivan",
                    LastName = "Popovski",
                    DateOfBirth = DateTime.Now.AddYears(-24),
                    ActiveCourseId = 1
                }
            };

            modelBuilder.Entity<Course>().HasData(courses);
            modelBuilder.Entity<Student>().HasData(student);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
