using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain.DomainModel.SizeApp;

namespace ProductService.Infrastructure.EntityConfigurations
{
    public class SizeEntityTypeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description)
                .HasMaxLength(500);

            builder.Property(x => x.Code)
                .HasMaxLength(10);

            builder.Property(x => x.Name)
                .HasMaxLength(255);
        }
    }
}
