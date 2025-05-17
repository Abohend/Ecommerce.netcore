using Ecommerce.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Utilities;

namespace Ecommerce.DataAccess.Data
{
    public static class ModelBuilderExtensions
    {
        static string adminRoleId = Guid.NewGuid().ToString();
        static string customerRoleId = Guid.NewGuid().ToString();
        static string editorRoleId = Guid.NewGuid().ToString();
        public static void SeedRoles(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = adminRoleId,
                    Name = CustomRoles.admin,
                    NormalizedName = CustomRoles.admin.ToUpper()
                },
                new IdentityRole
                {
                    Id = customerRoleId,
                    Name = CustomRoles.customer,
                    NormalizedName = CustomRoles.customer.ToUpper()
                },
                new IdentityRole
                {
                    Id = editorRoleId,
                    Name = CustomRoles.editor,
                    NormalizedName = CustomRoles.editor.ToUpper()
                }
            );
        }

        public static void SeedAdminUser(this ModelBuilder modelBuilder, IConfiguration configuration)
        {
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            var adminUser = new ApplicationUser
            {
                Id = Guid.NewGuid().ToString(),
                Name = configuration["Admin:Name"] ?? "",
                Email = configuration["Admin:Email"],
                NormalizedEmail = configuration["Admin:Email"]?.ToUpper(),
                UserName = configuration["Admin:Email"],
                NormalizedUserName = configuration["Admin:Email"]?.ToUpper(),
                PasswordHash = passwordHasher.HashPassword(null!, configuration["Admin:Password"]!),
                EmailConfirmed = true
            };

            modelBuilder.Entity<ApplicationUser>().HasData(adminUser);

            // Assign the admin role to the admin user
            modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    UserId = adminUser.Id,
                    RoleId = adminRoleId
                }
            );
        }

        public static void SeedCustomerUsers(this ModelBuilder modelBuilder, IConfiguration configuration)
        {
            var customersSection = configuration.GetSection("Customers");
            foreach (var customer in customersSection.GetChildren())
            {
                var customerData = customer.Get<Dictionary<string, string>>();
                var customerId = Guid.NewGuid().ToString();
                // add user
                modelBuilder.Entity<ApplicationUser>().HasData(
                    new ApplicationUser
                    {
                        Id = customerId,
                        Name = customerData!["Name"],
                        Email = customerData["Email"],
                        NormalizedEmail = customerData["Email"].ToUpper(),
                        UserName = customerData["Email"],
                        NormalizedUserName = customerData["Email"].ToUpper(),
                        PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(null!, customerData["Password"]),
                        EmailConfirmed = true
                    }
                );
                // assign role ("customer")
                modelBuilder.Entity<IdentityUserRole<string>>().HasData(
                    new IdentityUserRole<string>
                    {
                        UserId = customerId,
                        RoleId = customerRoleId
                    }
                );
            }
        }
        
        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new List<Category>
                {
                    new Category
                    {
                        Id = 1,
                        Name = "Mobile Phones",
                        Description = "All About Mobile Phones",
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Laptops",
                        Description = "All About Laptops",
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Tablets",
                        Description = "All About Tablets",
                    }
                }
            );
        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new List<Product>
                {
                    new Product
                    {
                        Id = 1,
                        Name = "Iphone 14 Pro",
                        Description = "Iphone 14 Pro Max",
                        Image = "images/products/image1.webp",
                        Price = 1200,
                        CategoryId = 1
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Samsung Galaxy S23",
                        Description = "Samsung Galaxy S23 Ultra",
                        Image = "images/products/image2.webp",
                        Price = 1000,
                        CategoryId = 1
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Dell Inspiron 15",
                        Description = "Dell Inspiron 15 3000",
                        Image = "images/products/image3.jpg",
                        Price = 1500,
                        CategoryId = 2
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "HP Pavilion",
                        Description = "HP Pavilion 15",
                        Image = "images/products/image4.jpg",
                        Price = 1400,
                        CategoryId = 2
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Hwawei MatePad",
                        Description = "Hwawei MatePad Pro",
                        Image = "images/products/image5.jpg",
                        Price = 600,
                        CategoryId = 3
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "Samsung Galaxy Tab S8",
                        Description = "Samsung Galaxy Tab S8",
                        Image = "images/products/image6.jpg",
                        Price = 700,
                        CategoryId = 3
                    }
                }
            );
        }

    }
}