using Microsoft.AspNetCore.Identity;

namespace ChopChop.Data.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string UserId{ get; set; } = null!;
        public virtual IdentityUser User { get; set; } = null!;

        public virtual ICollection<Ingredient> Ingredients { get; set; } = new HashSet<Ingredient>();
        public virtual ICollection<Category> Categories { get; set; } = new HashSet<Category>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<Favorite> Favorites { get; set; } = new HashSet<Favorite>();

    }
}
