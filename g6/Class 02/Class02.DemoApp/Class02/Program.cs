using Microsoft.AspNetCore.Routing.Constraints;

namespace Class02
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

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


            // Convetional routing
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            app.MapControllerRoute("all_courses",
                pattern: "courses/all",
                defaults: new { controller = "Course", action = "GetAllCourses" });


            app.MapControllerRoute("course_by_id",
                pattern: "courses/{id}",
                defaults: new { controller = "Course", action = "GetCourseById" });


            app.MapControllerRoute("course_by_name",
                pattern: "courses/byname/{name}",
                defaults: new { controller = "Course", action = "GetCourseByName" },
                constraints: new { name = new MinLengthRouteConstraint(5)});


            app.MapControllerRoute("course_by_id_or_by_name",
                pattern: "courses/{id}/{name}",
                defaults: new { controller = "Course", action = "GetCourseByIdOrName" });



            app.Run();
        }
    }
}