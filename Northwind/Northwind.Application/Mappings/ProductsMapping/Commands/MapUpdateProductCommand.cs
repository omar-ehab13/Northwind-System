using Northwind.Application.Features.Products.Commands.UpdateProduct;
using Northwind.Core.Entities;

namespace Northwind.Application.Mappings.ProductsMapping.Commands
{
    public static class MapUpdateProductCommand
    {
        public static Product FromUpdateProductCommandToProduct(this UpdateProductCommand command, Product product, Category category, Supplier supplier)
        {
            product.ProductName = command.ProductName;
            product.CategoryId = category.CategoryId;
            product.SupplierId = supplier.SupplierId;
            product.UnitPrice = command.UnitPrice;

            return product;
        }
    }
}
