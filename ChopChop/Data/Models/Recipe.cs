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
    }
}
