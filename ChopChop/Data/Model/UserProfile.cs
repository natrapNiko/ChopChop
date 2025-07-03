using Microsoft.AspNetCore.Identity;

namespace ChopChop.Data.Models
{
    public class UserProfile
    {
        public string UserId { get; set; } = null!;

        public virtual IdentityUser User { get; set; } = null!;

        public int RecipeId { get; set; }

        public virtual Recipe Recipe { get; set; } = null!;

    }
}
