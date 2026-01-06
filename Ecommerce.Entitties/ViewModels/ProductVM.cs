using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Entities.ViewModels
{
    public class ProductVM 
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string CategoryName { get; set; } = string.Empty;
    }
}
