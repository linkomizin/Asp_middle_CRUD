using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configuration
{
    internal sealed class ProviderConfiguration : IEntityTypeConfiguration<Provider>
    {
        public void Configure(EntityTypeBuilder<Provider> builder)
        {
            builder.ToTable(nameof(Provider));
            builder.HasKey(provider => provider.Id);
            builder.Property(provider => provider.Id).ValueGeneratedOnAdd();
            builder.Property(provider => provider.Name).IsRequired(true);
        }
    }
}
