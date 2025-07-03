
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

            entity.Property(r => r.Instructions)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(r => r.ImageUrl)
                .IsRequired(false);

            entity.Property(r => r.AuthorId)
               .IsRequired();

            entity.Property(r => r.IsDeleted)
                .HasDefaultValue(false);

            entity.HasQueryFilter(r => r.IsDeleted == false);

            entity.HasOne(r => r.Author)
            .WithMany()
            .HasForeignKey(r => r.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(r => r.Category)
                .WithMany(c =>  c.Recipes)
                .HasForeignKey(r =>r.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(r => r.UsersProfiles)
                .WithOne(up => up.Recipe)
                .HasForeignKey(up => up.RecipeId);

            entity.HasMany(r => r.Ingredients)
                .WithOne(i => i.Recipe)
                .HasForeignKey(i => i.RecipeId);


            entity.HasMany(r => r.Comments)
                .WithOne(co => co.Recipe)
                .HasForeignKey(co => co.RecipeId)
                .OnDelete(DeleteBehavior.Cascade);

            
        }
    }
}
