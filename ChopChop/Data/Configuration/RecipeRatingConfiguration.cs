using ChopChop.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChopChop.Data.Configuration
{
    public class RecipeRatingConfiguration : IEntityTypeConfiguration<RecipeRating>
    {
        public void Configure(EntityTypeBuilder<RecipeRating> entity)
        {
            entity.HasKey(rr => new { rr.UserId, rr.RecipeId });

            entity.Property(rr => rr.Value)
                .IsRequired();

            entity.HasOne(rr => rr.User)
                .WithMany()
                .HasForeignKey(rr => rr.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(rr => rr.Recipe)
                .WithMany(rr => rr.Ratings)
                .HasForeignKey(rr => rr.RecipeId)
                .IsRequired(false);

        }
    }
}
