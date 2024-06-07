using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


var app = builder.Build();

// => we are saying to our app to use routing
app.UseRouting();

// => we are saying that our app will use the default map for routing which is 
//this default route will look like => localhost:4325 =>  Courses/GetCourseById
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

// Conventional routing - manually mapping
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "allCourses", // this will be the name of the route
    pattern: "courses/allcourses", // => this will be the pattern or what comes after localhost in our URL
    defaults: new { controller = "Courses", action = "GetAllCourses" }); // => we are saying on this route provided on the above line, which controller and method to be triggered

app.MapControllerRoute(
    name: "course_by_name_with_contraint",
    pattern: "courses/{name}",
    defaults: new { name = new MinLengthRouteConstraint(5) }); // => length contraint with min 5 chars

app.MapControllerRoute(
    name: "course_with_default_value",
    pattern: "courses/{id}",
    defaults: new { controller = "Courses", action = "GetCourse" });

app.MapControllerRoute(
    name: "courses_multiple_params",
    pattern: "courses/{index}/{name}",
    defaults: new { controller = "Courses", action = "GetCourseByIdOrName" });



// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Home/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
