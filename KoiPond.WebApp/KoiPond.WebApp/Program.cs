using KoiPond.Repositories;
using KoiPond.Repositories.Entities;
using KoiPond.Repositories.Interfaces;
using KoiPond.Services;
using KoiPond.Services.Interfaces;

namespace KoiPond.WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //DI
            builder.Services.AddDbContext<KoiPond2024DbContext>();
            //DI repository
            builder.Services.AddScoped<IKoiPondAccountRepository, KoiPondAccountRepository>();
            //DI service
            builder.Services.AddScoped<IKoiPondAccountService, KoiPondAccountService>();
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
