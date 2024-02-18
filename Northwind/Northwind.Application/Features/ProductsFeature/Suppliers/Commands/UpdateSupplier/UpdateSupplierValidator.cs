using FluentValidation;
using Northwind.Application.Services.Contracts;

namespace Northwind.Application.Features.ProductsFeature.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierValidator : AbstractValidator<UpdateSupplierCommand>
    {
        private readonly ISupplierService supplierService;

        public UpdateSupplierValidator(ISupplierService supplierService)
        {
            this.supplierService = supplierService;

            RuleFor(s => s.CompanyName)
                .NotEmpty().WithMessage("The Company name is empty")
                .NotNull().WithMessage("The CompanyName is null");

            RuleFor(s => new { s.SupplierId, s.CompanyName })
                .MustAsync(async (key, CancellationToken) => !await supplierService.IsNameExistsExcept(key.CompanyName, key.SupplierId))
                .WithMessage("The company is already exists, the name must be uniques");
        }
    }
}
