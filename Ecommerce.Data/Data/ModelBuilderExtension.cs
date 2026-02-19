using Ecommerce.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Utilities;

namespace Ecommerce.DataAccess.Data
{
    public static class ModelBuilderExtensions
    {


        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new List<Category>
                {
                    new Category
                    {
                        Id = 1,
                        Name = "Fruits",
                        Description = "Fresh fruits",
                        Image = "images/categories/Fruits.png"
                    },
                    new Category
                    {
                        Id = 2,
                        Name = "Vegetables",
                        Description = "Fresh vegetables",
                        Image = "images/categories/Vegetables.jpg"
                    },
                    new Category
                    {
                        Id = 3,
                        Name = "Bread",
                        Description = "High quality bread",
                        Image = "images/categories/Bread.jpg"
                    },
                    new Category
                    {
                        Id = 4,
                        Name = "Meat",
                        Description = "All meat types",
                        Image = "images/categories/Meat.jpg"
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
                        Name = "Grapes",
                        Description = "Fresh grapes",
                        Image = "images/products/grapes.jpg",
                        Price = 4.99m,
                        CategoryId = 1
                    },
                    new Product
                    {
                        Id = 2,
                        Name = "Raspberries",
                        Description = "Fresh Raspberries",
                        Image = "images/products/Raspberries.jpg",
                        Price = 5.99m,
                        CategoryId = 1
                    },
                    new Product
                    {
                        Id = 3,
                        Name = "Brocoli",
                        Description = "Fresh brocoli",
                        Image = "images/products/Brocoli.jpg",
                        Price = 2.5m,
                        CategoryId = 2
                    },
                    new Product
                    {
                        Id = 4,
                        Name = "Potatoes",
                        Description = "High quality potatoes",
                        Image = "images/products/Potatoes.jpg",
                        Price = 1.4m,
                        CategoryId = 2
                    },
                    new Product
                    {
                        Id = 5,
                        Name = "Breadsticks",
                        Description = "Wellbacked breadsticks",
                        Image = "images/products/Breadsticks.jpg",
                        Price = 1.93m,
                        CategoryId = 3
                    },
                    new Product
                    {
                        Id = 6,
                        Name = "Croissant",
                        Description = "Wellbacked croissant",
                        Image = "images/products/Croissant.jpg",
                        Price = 2.14m,
                        CategoryId = 3
                    },
                    new Product
                    {
                        Id = 7,
                        Name = "Beef",
                        Description = "Basic cuts of beef",
                        Image = "images/products/Beef.jpg",
                        Price = 9.14m,
                        CategoryId = 4
                    },
                    new Product
                    {
                        Id = 8,
                        Name = "Lamp",
                        Description = "Basic cuts of lamp meat",
                        Image = "images/products/Lamp.webp",
                        Price = 10.45m,
                        CategoryId = 4
                    }
                }
            );
        }

        public static void SeedContactInfo(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactInfo>().HasData(
                new ContactInfo
                {
                    Id = 1,
                    Address = "123 Street, Nasr City, Egypt",
                    Phone = "+201065964363",
                    Email = "info@example.com"
                }
            );
        }
    }
}