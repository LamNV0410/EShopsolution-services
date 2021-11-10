using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain.DomainModel.Product_DiscountApp;

namespace ProductService.Infrastructure.EntityConfigurations
{
    public class ProductDiscountEntityTypeConfiguration : IEntityTypeConfiguration<ProductDiscount>
    {
        public void Configure(EntityTypeBuilder<ProductDiscount> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .IsRequired(true);

            builder.Property(x => x.DiscountId)
                .IsRequired(true);
        }
    }
}
