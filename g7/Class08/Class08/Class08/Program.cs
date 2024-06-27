using Class08.Filters;
using Class08.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
//builder.Services.AddControllersWithViews(); // => The defailt behaviour

// => How can we add global filter to our controller with views or with other words application
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add<LogFilter>();
});

var app = builder.Build();

app.UseMiddleware<MiddleWare2>();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    //app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.UseAuthorization();

app.MapRazorPages();

app.Run();
