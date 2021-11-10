using EshopSolution.Extensions.BaseDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OrderService.Domain.DomainModel;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.DBContext
{
    public class OrderDBContext : BaseDbContext, IBaseRepository
    {
        public OrderDBContext(DbContextOptions<OrderDBContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("OrderService");

            #region EntityTypeConfiguration


            #endregion
        }

        public class TemplateContextDesignFactory : IDesignTimeDbContextFactory<OrderDBContext>
        {
            public OrderDBContext CreateDbContext(string[] args)
            {
                string serverConn = "Server=DESKTOP-NA9CFEP\\MSSQLSERVER01;Initial Catalog=ESHOPORDERDB;Trusted_Connection=True;";
                var optionsBuilder = new DbContextOptionsBuilder<OrderDBContext>()
                    .UseSqlServer(serverConn)
                    .EnableSensitiveDataLogging(true);
                return new OrderDBContext(optionsBuilder.Options);
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
