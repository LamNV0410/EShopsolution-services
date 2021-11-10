using EshopSolution.Extensions.BaseDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ProductService.Domain.DomainModel.CategoryApp;
using ProductService.Domain.DomainModel.DiscountApp;
using ProductService.Domain.DomainModel.Product_DiscountApp;
using ProductService.Domain.DomainModel.Product_SizeApp;
using ProductService.Domain.DomainModel.ProductApp;
using ProductService.Domain.DomainModel.ProductImageApp;
using ProductService.Domain.DomainModel.SizeApp;
using ProductService.Infrastructure.EntityConfigurations;
using System.Threading;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.DBContext
{
    public class ProductDbContext : BaseDbContext, IBaseRepository
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<ProductDiscount> ProductDiscounts { get; set; }
        public DbSet<ProductSize> ProductSizes { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Size> Sizes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ProductService");

            #region EntityTypeConfiguration

            modelBuilder.ApplyConfiguration(new CategoryEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DiscountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductDiscountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductImageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ProductSizeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SizeEntityTypeConfiguration());
            
            #endregion
        }

        public class TemplateContextDesignFactory : IDesignTimeDbContextFactory<ProductDbContext>
        {
            public ProductDbContext CreateDbContext(string[] args)
            {
                string serverConn = "Server=DESKTOP-SHT6731;Initial Catalog=ESHOPPRODUCTSDB;User Id=sa;Password=123456;";
                var optionsBuilder = new DbContextOptionsBuilder<ProductDbContext>()
                    .UseSqlServer(serverConn)
                    .EnableSensitiveDataLogging(true);
                return new ProductDbContext(optionsBuilder.Options);
            }
        }

        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync();
        }

        public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            await base.SaveChangesAsync();
            return true;
        }
    }
}
