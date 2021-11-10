using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SystemService.Domain.DomainModel;

namespace SystemService.Infrastructure.EntityConfigurations
{
    class UserTypeEntityTypeConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TypeName)
                .HasMaxLength(255);
        }
    }
}
