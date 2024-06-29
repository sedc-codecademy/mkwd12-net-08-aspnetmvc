using Microsoft.EntityFrameworkCore;
using TodoApplication.DataAccess;
using TodoApplication.DataAccess.EFImplementations;
using TodoApplication.DataAccess.Implementations;
using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;
using TodoApplication.Services;
using TodoApplication.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Register Database
// Example 01
//string connectionString = "Server=.\\SQLEXPRESS;Database=TodoAppDb;Trusted_Connection=True;Integrated Security=True;Encrypt=False;";

//builder.Services.AddDbContext<TodoAppDbContext>(options => options.UseSqlServer(connectionString));

// Example 02 (better way)
string connectionString = builder.Configuration.GetConnectionString("TodoAppConnectionString");

builder.Services.AddDbContext<TodoAppDbContext>(options => options.UseSqlServer(connectionString));
#endregion

#region Register Repositories
// ===> If we want to use InMemoryDb implementation
builder.Services.AddTransient<ITodoRepository, TodoRepository>();
builder.Services.AddTransient<IRepository<Category>, CategoryRepository>();
builder.Services.AddTransient<IRepository<Status>, StatusRepository>();
#endregion

#region Register Services
builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddTransient<IFilterService, FilterService>();
#endregion

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
