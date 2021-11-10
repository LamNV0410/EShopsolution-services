using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProductService.Domain.DomainModel.DiscountApp;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Infrastructure.EntityConfigurations
{
    public class DiscountEntityTypeConfiguration : IEntityTypeConfiguration<Discount>
    {
        public void Configure(EntityTypeBuilder<Discount> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Description)
                .HasMaxLength(500)
                .IsRequired(false);

            builder.Property(x => x.Code)
                .HasMaxLength(20);
        }
    }
}
