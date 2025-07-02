
namespace ChopChop.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public DateTime CreatedDate { get; set; }

        public string UserId { get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;

        public int RecipeId { get; set; }
        public virtual Recipe Recipe { get; set; } = null!;

    }
}
