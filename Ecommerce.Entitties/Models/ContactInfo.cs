using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Entities.Models
{
    public class ContactInfo
    {
        public int Id { get; set; }
        
        [Required]
        public string Address { get; set; } = string.Empty;
        
        [Required]
        public string Phone { get; set; } = string.Empty;
        
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
