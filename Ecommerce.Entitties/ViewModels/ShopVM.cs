using Ecommerce.Entities.Models;
using X.PagedList;

namespace Ecommerce.Entities.ViewModels
{
    public class ShopVM
    {
        public IPagedList<Product> Products { get; set; } = null!;
        public List<CategoryWithCountVM> Categories { get; set; } = new();
        public int? CategoryId { get; set; }
        public string? Search { get; set; }
        public string? Sort { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
