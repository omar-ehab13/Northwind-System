using MediatR;
using Northwind.Application.Mappings.ProductsMapping.Commands;
using Northwind.Core.Entities;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.Products.Commands.AddProduct
{
    public class AddProductHandler : ResponseHandler, IRequestHandler<AddProductCommand, GenericResponse<Product>>
    {
        private readonly IRepositoryManager repositoryManager;

        public AddProductHandler(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<GenericResponse<Product>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            // Validate Request Data
            var category = await repositoryManager.Categories
                .FindAsync(c => c.CategoryName == request.CategoryName, trackChanges: false);

            if (category == null) return BadRequest<Product>("Category Name Not Found");

            var supplier = await repositoryManager.Suppliers
                .FindAsync(s => s.CompanyName == request.Supplier, trackChanges: false);

            if (supplier == null) return BadRequest<Product>("Supplier Not Found");

            // Map
            var product = request.FromAddProductCommandToProduct(category, supplier);

            // Create New Product In DB
            if (!await repositoryManager.Products.CreateAsync(product))
                return BadRequest<Product>("Cannot create new product");

            // Save Changes
            await repositoryManager.SaveChangesAsync();

            // Return Success
            return Created(product);
        }
    }
}
