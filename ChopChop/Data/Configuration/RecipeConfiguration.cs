
namespace ChopChop.Data.Configuration
{
    using ChopChop.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> entity)
        {
            entity.HasKey(r =>  r.Id);

            entity.Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(r => r.Description)
                .IsRequired()
                .HasMaxLength(5000);

            entity.Property(r => r.ImageUrl)
                .IsRequired(false);

            entity.Property(r => r.UserId)
               .IsRequired();

            entity.Property(r => r.IsDeleted)
                .HasDefaultValue(false);

            entity.HasQueryFilter(r => r.IsDeleted == false);

            entity.HasOne(r => r.User)
            .WithMany()
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(r => r.Category)
                .WithMany(c =>  c.Recipes)
                .HasForeignKey(r =>r.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(r => r.Ingredients)
                .WithOne(i => i.Recipe)
                .HasForeignKey(i => i.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(r => r.Comments)
                .WithOne(co => co.Recipe)
                .HasForeignKey(co => co.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasMany(r => r.Favorites)
                .WithOne(f => f.Recipe)
                .HasForeignKey(f => f.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
