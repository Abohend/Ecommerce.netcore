using Ecommerce.Entities.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Utilities;
using Microsoft.AspNetCore.Identity.UI.Services;
using Ecommerce.Entities.Models;
using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Implementations;
using Stripe;
using FileService = Ecommerce.Web.Services.FileService;
using Ecommerce.Web.Mapping;
using Ecommerce.Web.Filters;

namespace Ecommerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews(options =>
            {
                options.Filters.Add<WebsiteViewCounterFilter>();
            }).AddRazorRuntimeCompilation();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();
            builder.Services.AddDbContext<Context>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.Configure<StripeSettings>(builder.Configuration.GetSection("Stripe"));

            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(opt =>
            {
                opt.Lockout.AllowedForNewUsers = false;
            })
                .AddEntityFrameworkStores<Context>()
                .AddDefaultTokenProviders()
                .AddDefaultUI();

            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<FileService>();
            builder.Services.AddSingleton<IEmailSender, EmailSender>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            // Seed Database
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                var configuration = services.GetRequiredService<IConfiguration>();
                await DbInitializer.InitializeAsync(userManager, roleManager, configuration);
            } 


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseStatusCodePagesWithReExecute("/errors/404");

            StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe:SecretKey").Get<string>();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "Customer",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            await app.RunAsync();
        }
    }
}
