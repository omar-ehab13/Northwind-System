using Northwind.Application.Features.ProductsFeature.Products.Commands.UpdateProduct;
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
            product.QuantityPerUnit = command.QuantityPerUnit;
            product.UnitsInStock = command.UnitsInStock;
            product.UnitsOnOrder = command.UnitsOnOrder;
            product.ReorderLevel = command.ReorderLevel;
            product.Discontinued = command.Discontinued;

            return product;
        }
    }
}
