using Microsoft.EntityFrameworkCore;
using TodoApplication.DataAccess;
using TodoApplication.DataAccess.EFImplementations;
using TodoApplication.DataAccess.Implementations;
using TodoApplication.DataAccess.Interfaces;
using TodoApplication.Domain;
using TodoApplication.Services;
using TodoApplication.Services.Interfaces;
using TodoApplication.WebApp.Middleware;

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
// Here we register the dependencies using Dependency Injection

// ===> If we want to use InMemoryDb implementation
// Transient lifetime: A new instance of the service is created every time it is requested.
//builder.Services.AddTransient<ITodoRepository, TodoRepository>();
// Scoped lifetime: A new instance of the service is created once per client request (HTTP request in a web application).
//builder.Services.AddScoped<ITodoRepository, TodoRepository>();
// Singleton lifetime: A single instance of the service is created the first time it is requested and then reused for every subsequent request.
//builder.Services.AddSingleton<ITodoRepository, TodoRepository>();

// ===> If we want to use EF implementation
builder.Services.AddTransient<ITodoRepository, EFTodoRepository>();
// Everywhere we request ITodoRepository in the constructor, we get new instace from EFTodoRepository class
builder.Services.AddTransient<IRepository<Status>, EFStatusRepository>();
builder.Services.AddTransient<IRepository<Category>, EFCategoryRepository>();
#endregion


#region Register Services
builder.Services.AddTransient<ITodoService, TodoService>();
builder.Services.AddTransient<IFilterService, FilterService>();
#endregion

var app = builder.Build();

app.UseMiddleware<UrlLoggerMiddleware>();

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
