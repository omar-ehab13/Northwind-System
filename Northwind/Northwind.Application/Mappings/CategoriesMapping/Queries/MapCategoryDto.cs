using Northwind.Application.Features.ProductsFeature.Categories.Queries.GetAllCategories;
using Northwind.Application.Features.ProductsFeature.Categories.Queries.GetCategoryById;
using Northwind.Core.Entities;

namespace Northwind.Application.Mappings.CategoriesMapping.Queries
{
    public static class MapCategoryDto
    {
        public static GetAllCategoriesDto MapToGetAllCategoriesDto(this Category entity)
        {
            return new()
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                Description = entity.Description,
            };
        }

        public static GetCategoryByIdDto MapToGetCategoryByIdDto(this Category entity)
        {
            return new()
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName,
                Description = entity.Description,
            };
        }
    }
}
