using BT.Core;
using BTW.Datastore.EFCore.Core;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BT.Datastore.EFCore
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : IdentityDbContext<ApplicationUser>(options)
    {

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Brand> ProductBrands { get; set; }

        public DbSet<TechSpec> TechSpecs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Product>().ToTable("Product");
            modelBuilder.Entity<ProductImage>().ToTable("ProductImage");
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<TechSpec>().ToTable("TechSpec");

            // Category.Code unique constraint
            modelBuilder.Entity<Category>()
                .HasIndex(c => c.Code)
                .IsUnique();
        }
    }

}
