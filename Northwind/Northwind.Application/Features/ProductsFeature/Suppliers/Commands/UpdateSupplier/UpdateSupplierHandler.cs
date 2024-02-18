using AutoMapper;
using MediatR;
using Northwind.Core.Entities;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Suppliers.Commands.UpdateSupplier
{
    public class UpdateSupplierHandler :
        ResponseHandler, IRequestHandler<UpdateSupplierCommand, GenericResponse<object>>
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public UpdateSupplierHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

        public async Task<GenericResponse<object>> Handle(UpdateSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = await repositoryManager.Suppliers
                .GetByIdAsync(request.SupplierId);

            if (supplier == null) return NotFound<object>("Supplier Not Found");

            var newSupplier = mapper.Map<Supplier>(request);

            if (!await repositoryManager.Suppliers.UpdateAsync(supplier, newSupplier))
                return BadRequest<object>("Error During Updating Supplier");

            await repositoryManager.SaveChangesAsync();

            return Succeeded<object>(newSupplier);
        }
    }
}
