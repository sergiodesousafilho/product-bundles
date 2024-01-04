using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ProductBundles.Domain;

namespace ProductBundles.Infrastructure
{
    public class ProductBundlesDbContext: DbContext
    {
        protected readonly IConfiguration Configuration;

        public DbSet<Bundle> Bundle { get; set; }
        public DbSet<BundleProduct> BundleProduct { get; set; }
        public DbSet<Product> Product { get; set; }

        //public ProductBundlesDbContext(DbContextOptions<ProductBundlesDbContext> options) : base(options) 
        public ProductBundlesDbContext(IConfiguration configuration) : base()
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {            
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // [dbo].[Bundle]
            modelBuilder.Entity<Bundle>().HasKey(e => e.Id);

            // [dbo].[BundleProduct]
            modelBuilder.Entity<BundleProduct>().HasKey(e => e.Id);
            modelBuilder.Entity<BundleProduct>()
                .HasOne(bp => bp.Bundle)
                .WithMany(b => b.BundleProducts)
                .HasForeignKey(bp => bp.BundleId)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<BundleProduct>()
                .HasOne(bp => bp.Product)
                .WithMany()
                .HasForeignKey(bp => bp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);

            // [dbo].[Product]
            modelBuilder.Entity<Product>().HasKey(e => e.Id);
            modelBuilder.Entity<Product>()
                .HasMany(p => p.BundleProducts)
                .WithOne(bp => bp.Product)
                .HasForeignKey(bp => bp.ProductId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
