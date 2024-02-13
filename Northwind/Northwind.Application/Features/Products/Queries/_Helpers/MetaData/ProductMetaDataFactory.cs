using Microsoft.EntityFrameworkCore;
using Northwind.Application.Features.Products.Queries.GetAllProducts;
using Northwind.Core.Entities;
using Northwind.Core.Helpers.MetaData;

namespace Northwind.Application.Features.Products.Queries._Helpers.MetaData
{
    public class ProductMetaDataFactory : PaginationMetaDataFactory
    {
        public static async Task<ProductMetaData> CreateProductsMetaDataAsync(IQueryable<Product> products, GetAllProductsQuery request)
        {
            var count = await products.CountAsync();

            var paginationMetaData = CreatePaginationMetaData(request.PageNumber, request.PageSize, count);

            var minUnitPrice = await products.MinAsync(x => x.UnitPrice);
            var maxUnitPrice = await products.MaxAsync(x => x.UnitPrice);

            return new ProductMetaData(paginationMetaData, minUnitPrice ?? 0m, maxUnitPrice ?? 0m);
        }
    }
}
