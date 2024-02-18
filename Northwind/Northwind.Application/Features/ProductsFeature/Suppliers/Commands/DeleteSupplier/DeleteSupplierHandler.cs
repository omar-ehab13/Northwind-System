using MediatR;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierHandler
        : ResponseHandler, IRequestHandler<DeleteSupplierCommand, GenericResponse<object>>
    {
        private readonly IRepositoryManager repositoryManager;

        public DeleteSupplierHandler(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<GenericResponse<object>> Handle(DeleteSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await repositoryManager.Suppliers
                .GetByIdAsync(request.Id);

            if (supplier is null) return NotFound<object>();

            if (!await repositoryManager.Suppliers.RemoveAsync(supplier))
                return BadRequest<object>("Error during deleting supplier from DB");

            await repositoryManager.SaveChangesAsync();

            return Deleted<object>();
        }
    }
}
