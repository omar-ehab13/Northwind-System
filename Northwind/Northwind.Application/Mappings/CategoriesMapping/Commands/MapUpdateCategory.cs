using Northwind.Application.Features.ProductsFeature.Categories.Commands.UpdateCategory;
using Northwind.Core.Entities;

namespace Northwind.Application.Mappings.CategoriesMapping.Commands
{
    public static class MapUpdateCategory
    {
        public static Category MapUpdateCategoryCommandToCategoy(this UpdateCategoryCommand command, Category category)
        {
            category.CategoryName = command.CategoryName;
            category.Description = command.Description;

            return category;
        }
    }
}
