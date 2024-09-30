using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Entities.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public string? Adress { get; set; } 
    }
}
