namespace Ecommerce.Entities.ViewModels
{
    public class ShopQueryVM
    {
        public int PageNumber { get; set; } = 1;
        public int? CategoryId { get; set; }
        public string? Search { get; set; }
        public string? Sort { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }

}
