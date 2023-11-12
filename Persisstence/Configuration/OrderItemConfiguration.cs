using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal sealed class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable(nameof(OrderItem));

            builder.HasKey(orderItem => orderItem.Id);
            builder.Property(orderItem => orderItem.Id).ValueGeneratedOnAdd();
            
            builder.Property(orderItem => orderItem.Name).IsRequired(true);

            builder.Property(orderItem => orderItem.Quautity)
                .IsRequired(true)
                .HasPrecision(18,3);

            builder.Property(orderItem => orderItem.Unit).IsRequired(true);

            builder.Property(orderItem => orderItem.OrderId).IsRequired(true);
        }
    }
}
