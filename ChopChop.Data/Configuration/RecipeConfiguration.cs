
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
        }
    }
}
