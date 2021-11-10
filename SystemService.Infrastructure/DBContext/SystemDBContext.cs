using EshopSolution.Extensions.BaseDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Threading;
using System.Threading.Tasks;
using SystemService.Domain.DomainModel;
using SystemService.Infrastructure.EntityConfigurations;

namespace SystemService.Infrastructure.DBContext
{
    public class SystemDBContext : BaseDbContext, IBaseRepository
    {
        public SystemDBContext(DbContextOptions<SystemDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserType> UserTypes { get; set; }
        public DbSet<UserTypeRole> UserTypeRoles { get; set; }
        public DbSet<Avatar> Avatars { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("SystemService");

            #region EntityTypeConfiguration
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserTypeEntityTypeConfiguration());
            #endregion
        }

        public class TemplateContextDesignFactory : IDesignTimeDbContextFactory<SystemDBContext>
        {
            public SystemDBContext CreateDbContext(string[] args)
            {
                string serverConn = "Server=DESKTOP-SHT6731;Initial Catalog=ESHOPSYSTEMDB;User Id=sa;Password=123456;";
                var optionsBuilder = new DbContextOptionsBuilder<SystemDBContext>()
                    .UseSqlServer(serverConn)
                    .EnableSensitiveDataLogging(true);
                return new SystemDBContext(optionsBuilder.Options);
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
