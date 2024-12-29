using HabitTracker.Models;
using HabitTracker.Repos.Implementation;
using HabitTracker.Repos.IRepos;
using Microsoft.EntityFrameworkCore;

namespace HabitTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>
            (option => option.UseSqlServer(builder.Configuration.GetConnectionString("ConS")));

            builder.Services.AddScoped<IUserRepo, UserRepo>();
            builder.Services.AddScoped<IHabitRepo, HabitRepo>();
            builder.Services.AddScoped<ICategorey, CategoryRepo>();

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
