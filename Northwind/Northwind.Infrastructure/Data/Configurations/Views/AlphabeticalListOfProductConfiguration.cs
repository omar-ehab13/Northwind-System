using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Views;

namespace Northwind.Infrastructure.Data.Configurations.Views
{
    public class AlphabeticalListOfProductConfiguration : IEntityTypeConfiguration<AlphabeticalListOfProduct>
    {
        public void Configure(EntityTypeBuilder<AlphabeticalListOfProduct> builder)
        {
            builder
                .HasNoKey()
                .ToView("Alphabetical list of products");

            builder.Property(e => e.CategoryName).HasMaxLength(15);
            builder.Property(e => e.ProductName).HasMaxLength(40);
            builder.Property(e => e.QuantityPerUnit).HasMaxLength(20);
            builder.Property(e => e.UnitPrice).HasColumnType("money");
        }
    }
}
