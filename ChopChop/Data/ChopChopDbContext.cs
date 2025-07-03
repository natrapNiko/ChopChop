using ChopChop.Data.Model;
using ChopChop.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace ChopChop.Data
{
    public class ChopChopDbContext : IdentityDbContext
    {
        public ChopChopDbContext(DbContextOptions<ChopChopDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Recipe> Recipes { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<UserProfile> UsersProfiles { get; set; } = null!;
        public virtual DbSet<Ingredient> Ingredients { get; set; } = null!;
        public virtual DbSet<Comment> Comments { get; set; } = null!;
        public virtual DbSet<RecipeRating> RecipeRatings { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //app of configurations
            builder
                .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
