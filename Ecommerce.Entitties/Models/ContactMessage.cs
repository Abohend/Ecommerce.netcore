using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Entities.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Message { get; set; } = string.Empty;

        // Optional subject
        public string? Subject { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
