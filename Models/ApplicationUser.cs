using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BlogPlatform.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string? PublicName { get; set; }
        public string? Bio { get; set; }
        public DateOnly BirthDate { get; set; }

        

        public ICollection<UserPage> Pages { get; set; } = new List<UserPage>();
    }
}
