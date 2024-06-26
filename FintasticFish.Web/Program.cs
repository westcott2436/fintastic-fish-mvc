using Microsoft.EntityFrameworkCore;
using FintasticFish.Data;
using System.Configuration;
using FintasticFish.Data.Entities;
using SixLabors.ImageSharp.Web.DependencyInjection;

namespace SampleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddImageSharp();
            var config = builder.Configuration;
            var connectionString = config.GetConnectionString("LocalDB");
            builder.Services.AddDbContext<FintasticFishContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly("FintasticFish.Web")));
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseImageSharp();
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
