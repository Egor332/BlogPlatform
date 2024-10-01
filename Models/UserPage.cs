using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogPlatform.Models
{
    public class UserPage
    {
        public int Id { get; set; }

        public required string UserId { get; set; }
        [ForeignKey("UserId")]
        public required ApplicationUser User { get; set; }

    }
}
 