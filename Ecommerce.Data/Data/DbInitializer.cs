using Ecommerce.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Utilities;

namespace Ecommerce.DataAccess.Data
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            // Seed Roles
            if (!await roleManager.RoleExistsAsync(CustomRoles.admin))
            {
                await roleManager.CreateAsync(new IdentityRole(CustomRoles.admin));
            }
            if (!await roleManager.RoleExistsAsync(CustomRoles.editor))
            {
                await roleManager.CreateAsync(new IdentityRole(CustomRoles.editor));
            }
            if (!await roleManager.RoleExistsAsync(CustomRoles.customer))
            {
                await roleManager.CreateAsync(new IdentityRole(CustomRoles.customer));
            }

            // Seed Admin User
            var adminEmail = configuration["Admin:Email"];
            var adminUser = await userManager.FindByEmailAsync(adminEmail);
            if (adminUser == null)
            {
                adminUser = new ApplicationUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    Name = configuration["Admin:Name"],
                    PhoneNumber = configuration["Admin:Phone"], // Assuming phone is in config or null
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(adminUser, configuration["Admin:Password"]);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, CustomRoles.admin);
                }
            }

            // Seed Customer Users
            var customersSection = configuration.GetSection("Customers");
            foreach (var customerSection in customersSection.GetChildren())
            {
                var customerData = customerSection.Get<Dictionary<string, string>>();
                var customerEmail = customerData["Email"];
                var customerUser = await userManager.FindByEmailAsync(customerEmail);
                if (customerUser == null)
                {
                    customerUser = new ApplicationUser
                    {
                        UserName = customerEmail,
                        Email = customerEmail,
                        Name = customerData["Name"],
                        EmailConfirmed = true
                    };
                    var result = await userManager.CreateAsync(customerUser, customerData["Password"]);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(customerUser, CustomRoles.customer);
                    }
                }
            }
        }
    }
}
