using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderService.Domain.DomainModel;

namespace OrderService.Infrastructure.EntityConfigurations
{
    class OrderDetailEntityTypeConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductId)
                .IsRequired();
            builder.Property(x => x.OrderId)
                .IsRequired();
        }
    }
}
