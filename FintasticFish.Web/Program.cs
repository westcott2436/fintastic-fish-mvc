using Microsoft.EntityFrameworkCore;
using FintasticFish.Data;
using System.Configuration;
using FintasticFish.Data.Entities;

namespace SampleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //var connectionString = builder.Configuration.GetConnectionString("LocalDB");   
            var config = builder.Configuration;
            //TODO: Figure out why named configuration string are not working 2 locations.
            var connectionString = config.GetConnectionString("LocalDB");
            builder.Services.AddDbContext<FintasticFishContext>(options => options.UseSqlServer(config.GetConnectionString("LocalDB")));
            
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
