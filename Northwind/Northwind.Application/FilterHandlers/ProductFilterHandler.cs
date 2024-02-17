using Northwind.Application.Features.ProductsFeature.Products.Queries.GetAllProducts;
using Northwind.Application.Filters.ProductsFilters;
using Northwind.Core.Entities;
using Northwind.Core.Extensions;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.FilterHandlers
{
    public class ProductFilterHandler
    {
        private readonly IRepositoryManager _repositoryManager;

        public ProductFilterHandler(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public async Task<IQueryable<Product>> FilterAsync(IQueryable<Product> products, GetAllProductsQuery request)
        {
            products = await products.FilterProductsByCategoryAsync(request.Category, _repositoryManager);
            products = await products.FilterProductsBySupplierAsync(request.Supplier, _repositoryManager);

            products = await products.SearchAsync(request.Search, new string[] { nameof(Product.ProductName) });

            products = await products.SortAsync(request.OrderBy, nameof(Product.ProductId), typeof(Product));

            products = await products.FilterProductsInUnitPriceRangeAsync(request.MinUnitPrice, request.MaxUnitPrice);

            return products;
        }
    }
}
