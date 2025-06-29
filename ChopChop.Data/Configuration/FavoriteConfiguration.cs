
namespace ChopChop.Data.Configuration
{
    using ChopChop.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> entity)
        {
            entity.HasKey(f => new { f.UserId, f.RecipeId });

            entity.HasQueryFilter(f => f.Recipe.IsDeleted == false);

            entity.HasOne(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId);

            entity.HasOne(f => f.Recipe)
                .WithMany(r => r.Favorites)
                .HasForeignKey(f => f.RecipeId);
        }
    }
}
