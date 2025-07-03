
namespace ChopChop.Data.Models
{
    using Microsoft.AspNetCore.Identity;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
            public int Id { get; set; }

            [Required]
            [MinLength(5)]
            [MaxLength(250)]
            public string Content { get; set; } = null!;

            [Required]
            public DateTime PostedOn { get; set; }

            [Required]
            public string AuthorId { get; set; } = null!;
            public IdentityUser Author { get; set; } = null!;

            [Required]
            public int RecipeId { get; set; }
            public Recipe Recipe { get; set; } = null!;
    }
}
