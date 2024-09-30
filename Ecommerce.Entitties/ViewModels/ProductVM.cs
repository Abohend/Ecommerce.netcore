using Ecommerce.Entities.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Ecommerce.Entities.ViewModels
{
    public class ProductVM
    {
        public Product Product { get; set; } = new Product();
        public IEnumerable<SelectListItem>? Categories { get; set; } 
    }
}
