using Northwind.Core.Entities;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Filters.ProductsFilters
{
    public static class FilterProductsByDependentName
    {
        public static async Task<IQueryable<Product>> FilterProductsByCategoryAsync(this IQueryable<Product> query, string categoryName, IRepositoryManager repositoryManager)
        {
            if (string.IsNullOrEmpty(categoryName)) return query;

            var category = await repositoryManager.Categories
                .FindAsync(c => c.CategoryName.ToLower() == categoryName.ToLower(), trackChanges: false);

            if (category is null) return query;

            query = query.Where(p => p.CategoryId == category.CategoryId);

            return query;
        }

        public static async Task<IQueryable<Product>> FilterProductsBySupplierAsync(this IQueryable<Product> query, string supplierName, IRepositoryManager repositoryManager)
        {
            if (string.IsNullOrEmpty(supplierName)) return query;

            var supplier = await repositoryManager.Suppliers
                .FindAsync(c => c.CompanyName.ToLower() == supplierName.ToLower(), trackChanges: false);

            if (supplier is null) return query;

            query = query.Where(p => p.SupplierId == supplier.SupplierId);

            return query;
        }
    }
}
