using PizzaAppRefactored.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//INNJECT SERVICES
InjectionHelper.InjectServices(builder.Services);

//INJECT REPOSITORIES
InjectionHelper.InjectRepositories(builder.Services);

//INJECT DB
InjectionHelper.InjectDbContext(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
