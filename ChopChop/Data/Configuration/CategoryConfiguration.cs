using ChopChop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChopChop.Data.Configuration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(ca => ca.Id);

            entity.Property(ca => ca.Name)
                .IsRequired()
                .HasMaxLength(20);

            entity.HasMany(ca => ca.Recipes)
                .WithOne(r => r.Category)
                .HasForeignKey(r => r.CategoryId);

        }
    }
}
