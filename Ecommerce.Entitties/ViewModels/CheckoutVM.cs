using Ecommerce.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Entities.ViewModels
{
    public class CheckoutVM
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        [RegularExpression(@"^01(0|1|2|5)[0-9]{8}$", ErrorMessage = "Invalid Egyptian mobile phone number.")]
        public string Phone { get; set; } = string.Empty;
        public IEnumerable<ShoppingCartItem>? ShoppingCartItems { get; set; }
        public decimal Total { get; set; } = 0;
    }
}
