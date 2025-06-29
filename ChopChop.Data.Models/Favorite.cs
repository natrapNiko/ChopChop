
namespace ChopChop.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    public class Favorite
    {
        public string UserId { get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;
        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; } = null!;
    }
}