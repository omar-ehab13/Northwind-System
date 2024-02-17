using MediatR;
using Northwind.Application.Mappings.ProductsMapping.Commands;
using Northwind.Core.Entities;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Products.Commands.UpdateProduct
{
    public class UpdateProductHandler : ResponseHandler, IRequestHandler<UpdateProductCommand, GenericResponse<Product>>
    {
        private readonly IRepositoryManager repositoryManager;

        public UpdateProductHandler(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<GenericResponse<Product>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            // validate data
            var category = await repositoryManager.Categories
                .FindAsync(c => c.CategoryName == request.CategoryName, trackChanges: false);

            if (category == null) return BadRequest<Product>("Invalid category name");

            var supplier = await repositoryManager.Suppliers
                .FindAsync(s => s.CompanyName == request.Supplier, trackChanges: false);

            if (supplier == null) return BadRequest<Product>("Invalid supplier name");

            // find the product
            var product = await repositoryManager.Products.GetByIdAsync(request.Id);

            if (product == null) return NotFound<Product>("The product not found");

            // update
            product = request.FromUpdateProductCommandToProduct(product, category, supplier);

            await repositoryManager.SaveChangesAsync();

            // return success
            return Succeeded(product, "Updated Successfully");
        }
    }
}
