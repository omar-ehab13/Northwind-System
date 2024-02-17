using FluentValidation;
using Northwind.Application.Services.Contracts;

namespace Northwind.Application.Features.ProductsFeature.Categories.Commands.AddCategory
{
    public class AddCategoryValidator : AbstractValidator<AddCategoryCommand>
    {
        private readonly ICategoryService categoryService;

        public AddCategoryValidator(ICategoryService categoryService)
        {
            this.categoryService = categoryService;

            ApplyValidationRules();
            ApplyCustomRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(c => c.CategoryName)
                .NotEmpty().WithMessage("Category Name Is Required");
        }

        public void ApplyCustomRules()
        {
            RuleFor(c => c.CategoryName)
                .MustAsync(async (key, CancellationToken) => !await categoryService.IsNameExists(key))
                .WithMessage("The Category Name Must Be Unique, The Name Is Already Exists");
        }
    }
}
