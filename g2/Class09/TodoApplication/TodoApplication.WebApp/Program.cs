using Microsoft.EntityFrameworkCore;
using TodoApplication.DataAccess;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

#region Register Database
string connectionString = "Server=.\\SQLEXPRESS;Database=TodoAppDb;Trusted_Connection=True;Integrated Security=True;Encrypt=False;";

builder.Services.AddDbContext<TodoAppDbContext>(options => options.UseSqlServer(connectionString));
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
