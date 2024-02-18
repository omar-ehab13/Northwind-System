using AutoMapper;
using MediatR;
using Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetAllSuppliers.MetaData;
using Northwind.Application.FilterHandlers;
using Northwind.Core.Extensions;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersHandler : ResponseHandler, IRequestHandler<GetAllSuppliersQuery, GenericResponse<List<GetAllSuppliersDto>>>
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public GetAllSuppliersHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }
        public async Task<GenericResponse<List<GetAllSuppliersDto>>> Handle(GetAllSuppliersQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await repositoryManager.Suppliers
                .GetAllAsync(trackChanges: false);

            suppliers = await new SupplierFilterHandler(repositoryManager).FilterAsync(suppliers, request);

            var supplierMetaData = await SupplierMetaDataFactory.CreateSupplierMetaData(suppliers, request);

            suppliers = await suppliers.PaginateAsync(request.PageNumber, request.PageNumber);

            var result = mapper.Map<List<GetAllSuppliersDto>>(suppliers);

            return Succeeded(result, supplierMetaData);
        }
    }
}
