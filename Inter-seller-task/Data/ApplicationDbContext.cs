using Inter_seller_task.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Inter_seller_task.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
            
        }
        public DbSet<User> Users => Set<User>();

        public DbSet<Skill> Skills => Set<Skill>();

        public DbSet<SellerSkill> SellerSkills => Set<SellerSkill>();

        public DbSet<Product> Products => Set<Product>();

        public DbSet<ProductBrand> ProductBrands => Set<ProductBrand>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ApplicationDbContext).Assembly);
        }

    }
}
