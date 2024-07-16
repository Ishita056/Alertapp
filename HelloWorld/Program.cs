using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using HelloWorld.Data;
//using HelloWorld.Services;
namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<HelloWorldContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("HelloWorldContext") ?? throw new InvalidOperationException("Connection string 'HelloWorldContext' not found.")));

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //Configuring Session Services in ASP.NET Core
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddHttpContextAccessor();

            //builder.Services.AddHostedService<ScheduledTaskService>();

            builder.Services.AddSession(options =>
            {
                //options.IdleTimeout = TimeSpan.FromSeconds(10);
                //options.IOTimeout = TimeSpan.FromSeconds(10);
                //options.Cookie.Name = ".MySampleMVCWeb.Session";
                //options.Cookie.HttpOnly = true;
                //options.Cookie.IsEssential = true;
                //options.Cookie.Path = "/";
                //options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();

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
