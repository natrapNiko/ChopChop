
namespace ChopChop.Data.Configuration
{
    using ChopChop.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(30);

            entity.HasData(GenerateSeedCategories());
        }

        List<Category> GenerateSeedCategories()
        {
            List<Category> seedCategories = new List<Category>()
            {
                new Category { Id = 1, Name = "Main Dishes" },
                new Category { Id = 2, Name = "Desserts" },
                new Category { Id = 3, Name = "Salads" },
                new Category { Id = 4, Name = "Soups" },
                new Category { Id = 5, Name = "Beverages" }
            };

            return seedCategories;
        }
    }
}
