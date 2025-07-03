using ChopChop.Data.Model;
using Microsoft.AspNetCore.Identity;

namespace ChopChop.Data.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Title { get; set; } = null!;

        public string Instructions { get; set; } = null!;

        public string? ImageUrl { get; set; }

        public string AuthorId { get; set; } = null!;

        public virtual IdentityUser Author { get; set; } = null!;

        public DateTime CreatedOn { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public virtual ICollection<UserProfile> UsersProfiles { get; set; } = new HashSet<UserProfile>();
        public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
        public virtual ICollection<RecipeRating> Ratings { get; set; } = new HashSet<RecipeRating>();


    }
}
