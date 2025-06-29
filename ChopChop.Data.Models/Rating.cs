
namespace ChopChop.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    public class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string UserId { get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;
        public int? RecipeId { get; set; }
        public virtual Recipe? Recipe { get; set; }
    }
}