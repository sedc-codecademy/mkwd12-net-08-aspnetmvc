using Class09_EF.DataAccess;
using Class09_EF.Helpers.DIHelper;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

//saving connection string from appsettings.json =>
var connectionString = builder.Configuration.GetConnectionString("StudentConnectionString");

//adding dbcontex to our app pipeline with our connection string =>
builder.Services.AddDbContext<StudentDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

//here we inject our repositories and services to our application
DependencyInjection.InjectRepositories(builder.Services);
DependencyInjection.InjectServices(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();
