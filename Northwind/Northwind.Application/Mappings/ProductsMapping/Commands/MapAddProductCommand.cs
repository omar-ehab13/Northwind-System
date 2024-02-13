using Northwind.Application.Features.Products.Commands.AddProduct;
using Northwind.Core.Entities;

namespace Northwind.Application.Mappings.ProductsMapping.Commands
{
    public static class MapAddProductCommand
    {
        public static Product FromAddProductCommandToProduct(this AddProductCommand addProductCommand, Category category, Supplier supplier)
        {
            return new Product
            {
                ProductName = addProductCommand.ProductName,
                CategoryId = category.CategoryId,
                SupplierId = supplier.SupplierId,
                UnitPrice = addProductCommand.UnitPrice,
            };
        }
    }
}
