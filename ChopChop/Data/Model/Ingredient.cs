using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChopChop.Data.Models
{
    public class Ingredient 
    {
            public int Id { get; set; }

            [Required]
            [MinLength(2)]
            [MaxLength(50)]
            public string Name { get; set; } = null!;

            [Required]
            public double Quantity { get; set; }

            [Required]
            [MaxLength(20)]
            public string Unit { get; set; } = null!; // например грамове,милилитри, броя, ч.л. и така нататак

            [Required]
            public int RecipeId { get; set; }
            [ForeignKey(nameof(RecipeId))]
             public Recipe Recipe { get; set; } = null!;
        
    }
}
