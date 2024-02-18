using FluentValidation;
using Northwind.Application.Services.Contracts;

namespace Northwind.Application.Features.ProductsFeature.Suppliers.Commands.AddSupplier
{
    public class AddSupplierValidator : AbstractValidator<AddSupplierCommand>
    {
        private readonly ISupplierService supplierService;

        public AddSupplierValidator(ISupplierService supplierService)
        {
            this.supplierService = supplierService;

            RuleFor(s => s.CompanyName)
                .NotEmpty().WithMessage("The Company name is empty")
                .NotNull().WithMessage("The CompanyName is null");

            RuleFor(s => s.CompanyName)
                .MustAsync(async (key, CancellationToken) => !await supplierService.IsNameExists(key))
                .WithMessage("The company is already exists, the name must be uniques");
        }
    }
}
