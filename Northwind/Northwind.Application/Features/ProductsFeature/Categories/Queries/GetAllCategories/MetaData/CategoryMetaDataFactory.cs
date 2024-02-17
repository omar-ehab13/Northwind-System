using Microsoft.EntityFrameworkCore;
using Northwind.Core.Entities;
using Northwind.Core.Helpers.MetaData;

namespace Northwind.Application.Features.ProductsFeature.Categories.Queries.GetAllCategories.MetaData
{
    public class CategoryMetaDataFactory : PaginationMetaDataFactory
    {
        public static async Task<CategoryMetaData> CreateCategoryMetaData(IQueryable<Category> categories, GetAllCategoriesQuery request)
        {
            var count = await categories.CountAsync();

            var paginationMetaData = CreatePaginationMetaData(request.PageNumber, request.PageSize, count);

            return new(paginationMetaData);
        }
    }
}
