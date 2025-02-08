namespace Ecommerce.Entities.Models
{
    public class ShoppingCartItem
    {
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public uint Amount { get; set; }
    }
}
