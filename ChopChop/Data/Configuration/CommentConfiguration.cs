using ChopChop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChopChop.Data.Configuration
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> entity)
        {
            entity.HasKey(co => co.Id);

            entity.Property(co => co.Content)
                .IsRequired()
                .HasMaxLength(250);

            entity.Property(co => co.PostedOn)
                .IsRequired();

            entity.HasOne(co => co.Author)
                .WithMany()
                .HasForeignKey(co => co.AuthorId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(co => co.Recipe)
                .WithMany(r => r.Comments)
                .HasForeignKey(co => co.RecipeId);

        }
    }
}
