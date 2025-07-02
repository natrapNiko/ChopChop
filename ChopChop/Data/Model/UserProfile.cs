using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ChopChop.Data.Models
{
    public class UserProfile
    {
        [Key]
        public string UserId { get; set; } = null!;
        public string DisplayName { get; set; } = null!;
        public string? ProfileImageUrl { get; set; }
        public virtual IdentityUser User { get; set; } = null!;
    }
}
