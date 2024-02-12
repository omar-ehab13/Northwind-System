using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Northwind.Core.Entities;

namespace Northwind.Infrastructure.Data.Configurations.Entities
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasIndex(e => e.CategoryName, "CategoryName");

            builder.Property(e => e.CategoryName).HasMaxLength(15);
            builder.Property(e => e.Description).HasColumnType("ntext");
            builder.Property(e => e.Picture).HasColumnType("image");
        }
    }
}
