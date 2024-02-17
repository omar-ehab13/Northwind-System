using MediatR;
using Northwind.Application.Mappings.ProductsMapping.Queries;
using Northwind.Core.Entities;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Products.Queries.GetProductById
{
    public class GetProductByIdHandler : ResponseHandler, IRequestHandler<GetProductByIdQuery, GenericResponse<GetProductByIdDto>>
    {
        private readonly IRepositoryManager repositoryManager;

        public GetProductByIdHandler(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<GenericResponse<GetProductByIdDto>> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            var product = await repositoryManager.Products
                .FindAsync(p => p.ProductId == request.Id, new string[] { nameof(Product.Category), nameof(Product.Supplier) }, false);

            if (product == null) return NotFound<GetProductByIdDto>("Product Not Found");

            var result = product.MapToGetProductByIdDto();

            return Succeeded(result);
        }
    }
}
