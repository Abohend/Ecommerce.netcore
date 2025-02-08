using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Entities.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string OrderStatus { get; set; } = string.Empty;
        public string PaymentStatus { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        [RegularExpression(@"^01(0|1|2|5)[0-9]{8}$", ErrorMessage = "Invalid Egyptian mobile phone number.")]
        public string Phone { get; set; } = string.Empty;
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }
        public IEnumerable<ShoppingCartItem>? ShoppingCartItems { get; set; }
        //stripe attributes
        public string? SessionId { get; set; }
        public string? PaymentIntentId { get; set; }
    }
}
