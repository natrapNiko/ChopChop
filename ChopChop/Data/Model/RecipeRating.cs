using ChopChop.Data.Models;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace ChopChop.Data.Model
{
    public class RecipeRating
    {
        [Required]
        public string UserId { get; set; } = null!;
        public IdentityUser User { get; set; } = null!;

        [Required]
        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; } = null!;

        [Required]
        [Range(1, 5)]
        public int Value { get; set; }

    }
}
