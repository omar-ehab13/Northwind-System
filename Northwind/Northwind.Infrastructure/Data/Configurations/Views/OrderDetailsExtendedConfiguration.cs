using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Views;

namespace Northwind.Infrastructure.Data.Configurations.Views
{
    public class OrderDetailsExtendedConfiguration : IEntityTypeConfiguration<OrderDetailsExtended>
    {
        public void Configure(EntityTypeBuilder<OrderDetailsExtended> entity)
        {
            entity
                .HasNoKey()
                .ToView("Order Details Extended");

            entity.Property(e => e.ExtendedPrice).HasColumnType("money");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.ProductName).HasMaxLength(40);
            entity.Property(e => e.UnitPrice).HasColumnType("money");
        }
    }
}
