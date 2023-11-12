using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal sealed class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable(nameof(Order));
            builder.HasKey(order => order.Id);
            
            builder.Property(order => order.Id).ValueGeneratedOnAdd();
            
            builder.Property(order => order.Number).IsRequired(true);

            builder.Property(order => order.Date)
                .IsRequired()
                .HasPrecision(7);
            
            builder.Property(order => order.ProviderId).IsRequired(true);
        }
    }
}
