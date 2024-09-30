using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPlatform.Models
{
    public class UserPage
    {
        public int Id { get; set; }
        
        

        [Required]
        public string? UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }

    }
}
