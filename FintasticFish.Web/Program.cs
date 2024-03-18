using Microsoft.EntityFrameworkCore;
using FintasticFish.Data;

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

            //TODO: Figure out why named configuration string are not working 2 locations.
            builder.Services.AddDbContext<FintasticFishContext>(options => options.UseSqlServer("Data Source=RAINBOW-PUKE\\SQLEXPRESS;Initial Catalog=FintasticFish; TrustServerCertificate=True; Integrated Security=SSPI;"));
            
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
