using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain.DomainModel.CategoryApp;

namespace ProductService.Infrastructure.EntityConfigurations
{
    public class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasMaxLength(255)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired(false);
        }
    }
}
