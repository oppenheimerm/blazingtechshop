using BT.Core;
using BTW.Datastore.EFCore.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace BT.Datastore.EFCore
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>        
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

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

            //  Brand.Code unique constraint
            modelBuilder.Entity<Brand>()
                .HasIndex(b => b.Code)
                .IsUnique();

            modelBuilder.Entity<Product>()
                .Property(p => p.BasePrice)
                .HasColumnType("Money");
        }
    }

}
