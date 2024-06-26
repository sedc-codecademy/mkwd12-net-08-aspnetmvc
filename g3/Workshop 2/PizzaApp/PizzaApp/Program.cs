using DataAccess;
using DataAccess.Implementation;
using DataAccess.Interface;
using Microsoft.EntityFrameworkCore;
using Services.Implementation;
using Services.Interfaces;

namespace PizzaApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<PizzaAppDbContext>(option => option.UseSqlServer(
                builder.Configuration.GetConnectionString("DefaultConnectionString")
                ));

            builder.Services.AddTransient<IPizzaRepository, PizzaRepository>();
            builder.Services.AddTransient<IPizzaService, PizzaService>();
            builder.Services.AddTransient(typeof(IRepository<>), typeof(Repository<>));

            //var a = builder.Configuration["MaxRetries"];

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}