using ChopChop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChopChop.Data.Configuration
{
    public class RatingConfiguration : IEntityTypeConfiguration<Rating>
    {
        public void Configure(EntityTypeBuilder<Rating> entity)
        {
            entity.HasKey(r => r.Id);

            entity.Property(r => r.Value)
                .IsRequired()
                .HasDefaultValue(1);

            entity.HasOne(r => r.User)
                .WithMany()
                .HasForeignKey(r => r.UserId);

            entity.HasOne(r => r.Recipe)
                .WithMany(r => r.Ratings)
                .HasForeignKey(r => r.RecipeId);
        }
    }
}
