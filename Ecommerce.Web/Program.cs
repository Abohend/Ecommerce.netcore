using Ecommerce.Entities.Repositories;
using Ecommerce.Web.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Utilities;
using Microsoft.AspNetCore.Identity.UI.Services;
using Ecommerce.Entities.Models;
using Ecommerce.DataAccess.Data;
using Ecommerce.DataAccess.Implementations;

namespace Ecommerce.Web
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();
            builder.Services.AddDbContext<Context>(options => 
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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

            var app = builder.Build();

            // seed data
            using (var scope = app.Services.CreateScope())
            {
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                
                // seed roles
                var roles = new[]
                {
                    new IdentityRole(CustomRoles.admin)
                    {
                        NormalizedName = CustomRoles.admin.ToUpper()
                    },
                    new IdentityRole(CustomRoles.customer)
                    {
                        NormalizedName = CustomRoles.customer.ToUpper()
                    },
                    new IdentityRole(CustomRoles.editor)
                    {
                        NormalizedName = CustomRoles.editor.ToUpper()
                    }
                };
                foreach (var role in roles)
                {
                    if (!await roleManager.RoleExistsAsync(role.Name!))
                    {
                        await roleManager.CreateAsync(role);
                    }
                }

                // seed default admin
                if (await userManager.FindByEmailAsync("mhmdabohend@gmail.com") == null)
                {
                    var admin = new ApplicationUser()
                    {

                        Name = "Mohamed Abohend",
                        Email = "mhmdabohend@gmail.com",
                        UserName = "mhmdabohend@gmail.com"
                    };
                    var res = await userManager.CreateAsync(admin, "Mm@12345");
                    await userManager.AddToRoleAsync(admin, CustomRoles.admin);
                }
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

            app.UseAuthorization();

            //app.MapControllerRoute(
            //    name: "default",
            //    pattern: "{area=Admin}/{controller=Products}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "Customar",
                pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}
