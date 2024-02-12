using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Entities;

namespace Northwind.Infrastructure.Data.Configurations.Entities
{
    public class CustomerDemographicConfiguration : IEntityTypeConfiguration<CustomerDemographic>
    {
        public void Configure(EntityTypeBuilder<CustomerDemographic> builder)
        {
            builder.HasKey(e => e.CustomerTypeId).IsClustered(false);

            builder.Property(e => e.CustomerTypeId)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("CustomerTypeID");

            builder.Property(e => e.CustomerDesc).HasColumnType("ntext");
        }
    }
}
