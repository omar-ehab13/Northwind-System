using Northwind.Application.Features.Products.Queries._Helpers.DTOs;
using Northwind.Core.Entities;

namespace Northwind.Application.Mappings.ProductsMapping.Queries
{
    public static class MapToProductDto
    {
        public static GetAllProductsDto MapToGetAllProductsDto(this Product product)
        {
            var category = product.Category;
            var supplier = product.Supplier;

            if (category == null || supplier == null) throw new NullReferenceException("Category or Supplier not included in produt data");

            return new GetAllProductsDto
            (
                ProductId: product.ProductId,
                ProductName: product.ProductName,
                Category: category.CategoryName,
                Supplier: supplier.CompanyName,
                UintPrice: product.UnitPrice
            );
        }

        public static GetProductByIdDto MapToGetProductByIdDto(this Product product)
        {
            var category = product.Category;
            var supplier = product.Supplier;

            if (category == null || supplier == null) throw new NullReferenceException("Category or Supplier not included in produt data");

            return new GetProductByIdDto
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                CategoryId = product.CategoryId,
                CategoryName = category.CategoryName,
                SupplierId = product.SupplierId,
                SupplierName = supplier.CompanyName,
                UnitPrice = product.UnitPrice,
                QuantityPerUnit = product.QuantityPerUnit,
                UnitsInStock = product.UnitsInStock,
                ReorderLevel = product.ReorderLevel,
                UnitsOnOrder = product.UnitsOnOrder,
                Discontinued = product.Discontinued
            };
        }
    }
}
