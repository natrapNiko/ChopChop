using ChopChop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChopChop.Data.Configuration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> entity)
        {
            entity.HasKey(up => new { up.UserId, up.RecipeId });

            entity.HasOne(up => up.User)
                .WithMany()
                .HasForeignKey(up => up.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(up => up.Recipe)
                .WithMany(r => r.UsersProfiles)
                .HasForeignKey(up => up.RecipeId);
        }
    }
}
