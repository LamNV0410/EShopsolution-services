using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain.DomainModel.Product_SizeApp;

namespace ProductService.Infrastructure.EntityConfigurations
{
    public class ProductSizeEntityTypeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductId)
                 .IsRequired(true);

            builder.Property(x => x.SizeId)
                .IsRequired(true);
        }
    }
}
