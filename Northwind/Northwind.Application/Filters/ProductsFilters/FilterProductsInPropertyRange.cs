using Northwind.Core.Entities;

namespace Northwind.Application.Filters.ProductsFilters
{
    public static class FilterProductsInPropertyRange
    {
        public static async Task<IQueryable<Product>> FilterProductsInUnitPriceRangeAsync
            (this IQueryable<Product> query, decimal minUnitPrice = 0m, decimal maxUnitPrice = int.MaxValue)
        {
            if (minUnitPrice >= maxUnitPrice) return query;

            query = await Task.FromResult(query.Where(p => p.UnitPrice >= minUnitPrice && p.UnitPrice <= maxUnitPrice));

            return query;
        }
    }
}
