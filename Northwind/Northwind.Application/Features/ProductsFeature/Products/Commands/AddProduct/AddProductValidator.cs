using FluentValidation;
using Northwind.Application.Services.Contracts;

namespace Northwind.Application.Features.ProductsFeature.Products.Commands.AddProduct
{
    public class AddProductValidator : AbstractValidator<AddProductCommand>
    {
        private readonly ICategoryService categoryService;
        private readonly ISupplierService supplierService;

        public AddProductValidator(ICategoryService categoryService, ISupplierService supplierService)
        {
            this.categoryService = categoryService;
            this.supplierService = supplierService;


            ApplyValidationRules();
            ApplyCustomRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(p => p.ProductName)
                .NotEmpty().WithMessage("Product Name Is Empty")
                .NotNull().WithMessage("Product Name Is Required");

            RuleFor(p => p.CategoryName)
                .NotEmpty().WithMessage("Category Is Empty!")
                .NotNull().WithMessage("Category Is Requierd");

            RuleFor(p => p.Supplier)
                .NotEmpty().WithMessage("Supplier Is Empty!")
                .NotNull().WithMessage("Supplier Is Requierd");
        }

        public void ApplyCustomRules()
        {
            RuleFor(p => p.CategoryName)
                .MustAsync(async (key, CancellationToken) => await categoryService.IsNameExists(key!))
                .WithMessage(key => $"`{key.CategoryName}` invalid category name");

            RuleFor(p => p.Supplier)
                .MustAsync(async (key, CancellationToken) => await supplierService.IsNameExists(key!))
                .WithMessage("Invalid Supplier");
        }
    }
}
