using Northwind.Application.Features.Products.Queries.DTOs;
using Northwind.Core.Entities;

namespace Northwind.Application.Mappings.ProductsMapping.Queries
{
    public static class MapToProductDto
    {
        public static ProductDto ToProductDto(this Product product)
        {
            return new ProductDto
            (
                ProductId: product.ProductId,
                ProductName: product.ProductName,
                Category: product.Category.CategoryName,
                Supplier: product.Supplier.CompanyName,
                UintPrice: product.UnitPrice
            );
        }
    }
}
