using Northwind.Application.Features.ProductsFeature.Products.Commands.AddProduct;
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
                QuantityPerUnit = addProductCommand.QuantityPerUnit,
                UnitsInStock = addProductCommand.UnitsInStock,
                UnitsOnOrder = addProductCommand.UnitsOnOrder,
                ReorderLevel = addProductCommand.ReorderLevel,
                Discontinued = addProductCommand.Discontinued
            };
        }
    }
}
