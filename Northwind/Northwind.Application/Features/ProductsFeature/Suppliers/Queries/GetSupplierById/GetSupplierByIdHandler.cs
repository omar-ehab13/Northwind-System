using AutoMapper;
using MediatR;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdHandler
        : ResponseHandler, IRequestHandler<GetSupplierByIdQuery, GenericResponse<GetSupplierByIdDto>>
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public GetSupplierByIdHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }
        public async Task<GenericResponse<GetSupplierByIdDto>> Handle(GetSupplierByIdQuery request, CancellationToken cancellationToken)
        {
            var supplier = await repositoryManager.Suppliers
                .GetByIdAsync(request.Id);

            if (supplier is null) return NotFound<GetSupplierByIdDto>("Supplier is not found");

            var result = mapper.Map<GetSupplierByIdDto>(supplier);

            return Succeeded(result);
        }
    }
}
