
namespace ChopChop.Data.Configuration
{
    using ChopChop.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> entity)
        {
            entity.HasKey(r => r.Id);

            entity.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(80);

            entity.Property(r => r.Instructions)
                .IsRequired()
                .HasMaxLength(3000);

            entity.Property(r => r.CreatedOn)
                .IsRequired();

            entity.HasOne(r => r.Author)
                .WithMany()
                .HasForeignKey(r => r.AuthorId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.Property(r => r.ImageUrl)
                .IsRequired(false);

            entity
                .Property(r => r.IsDeleted)
                .HasDefaultValue(false);

            //take only activ Recipe
            entity
                .HasQueryFilter(r => r.IsDeleted == false);

            entity.HasOne(r => r.Category)
                .WithMany(c => c.Recipes)
                .HasForeignKey(r => r.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(r => r.UsersRecipes)
                .WithOne(ur => ur.Recipe)
                .HasForeignKey(ur => ur.RecipeId);

            entity.HasMany(r => r.Ratings)
                .WithOne(r => r.Recipe)
                .HasForeignKey(r => r.RecipeId);

            entity.HasMany(r => r.Favorites)
                .WithOne(f => f.Recipe)
                .HasForeignKey(f => f.RecipeId);

            entity.HasData(GenerateSeedRecipes());
        }

        List<Recipe> GenerateSeedRecipes()
        {
            List<Recipe> seedRecipes = new List<Recipe>()
            {
                new Recipe
                {
                    Id = 1,
                    Title = "Classic Spaghetti Bolognese",
                    Instructions = "Cook pasta. In another pan, cook minced meat with tomato sauce, onion, and garlic. Combine and simmer.",
                    ImageUrl = "https://example.com/images/spaghetti.jpg",
                    AuthorId = "test-user",
                    CreatedOn = new DateTime(2024, 6, 1),
                    CategoryId = 1,
                    IsDeleted = false
                },
                new Recipe
                {
                    Id = 2,
                    Title = "Easy Pancakes",
                    Instructions = "Mix flour, eggs, milk, and sugar. Fry in a pan until golden on both sides. Serve with syrup.",
                    ImageUrl = "https://example.com/images/pancakes.jpg",
                    AuthorId = "test-user",
                    CreatedOn = new DateTime(2024, 6, 5),
                    CategoryId = 2,
                    IsDeleted = false
                },
                new Recipe
                {
                    Id = 3,
                    Title = "Fresh Greek Salad",
                    Instructions = "Chop cucumbers, tomatoes, olives, and feta cheese. Mix with olive oil and oregano.",
                    ImageUrl = "https://example.com/images/greek_salad.jpg",
                    AuthorId = "test-user",
                    CreatedOn = new DateTime(2024, 6, 10),
                    CategoryId = 3,
                    IsDeleted = false
                }
            };

            return seedRecipes;
        }

    }
}
