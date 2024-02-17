using Northwind.Application.Features.ProductsFeature.Categories.Commands.AddCategory;
using Northwind.Core.Entities;

namespace Northwind.Application.Mappings.CategoriesMapping.Commands
{
    public static class MapAddCategory
    {
        public static Category MapAddCategoryCommandToCategoy(this AddCategoryCommand command)
        {
            return new()
            {
                CategoryName = command.CategoryName,
                Description = command.Description,
            };
        }
    }
}
