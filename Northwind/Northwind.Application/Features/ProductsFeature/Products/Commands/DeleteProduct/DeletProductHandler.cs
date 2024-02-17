using MediatR;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Products.Commands.DeleteProduct
{
    public class DeletProductHandler : ResponseHandler, IRequestHandler<DeletProductCommand, GenericResponse<object>>
    {
        private readonly IRepositoryManager repositoryManager;

        public DeletProductHandler(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<GenericResponse<object>> Handle(DeletProductCommand request, CancellationToken cancellationToken)
        {
            var product = await repositoryManager.Products.GetByIdAsync(request.Id);

            if (product == null) return NotFound<object>("Product Not Found");

            if (!await repositoryManager.Products.RemoveAsync(product))
                return BadRequest<object>("Problem In Deleting Product In DB");

            await repositoryManager.SaveChangesAsync();

            return Deleted<object>();
        }
    }
}
