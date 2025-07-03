using ChopChop.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChopChop.Data.Configuration
{
    public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public void Configure(EntityTypeBuilder<Ingredient> entity)
        {
            entity.HasKey(i => i.Id);

            entity.Property(i => i.Name)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(i => i.Quantity)
                .IsRequired();

            entity.Property(i => i.Unit)
                .IsRequired()
                .HasMaxLength(20);

            entity.HasOne(i => i.Recipe)
                .WithMany(r => r.Ingredients)
                .HasForeignKey(i => i.RecipeId)
                .IsRequired(false);
        }
    }
}

