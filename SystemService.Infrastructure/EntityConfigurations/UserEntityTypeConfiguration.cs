using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemService.Domain.DomainModel;

namespace SystemService.Infrastructure.EntityConfigurations
{
    class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName)
                .HasMaxLength(255);
            builder.Property(x => x.LastName)
                .HasMaxLength(255);
            builder.Property(x => x.Email)
                .HasMaxLength(255);
            builder.Property(x => x.Address)
                .HasMaxLength(255);
        }
    }
}
