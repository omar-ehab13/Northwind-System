using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetAllSuppliersNames
{
    public class GetAllSuppliersNamesHandler :
        ResponseHandler, IRequestHandler<GetAllSuppliersNamesQuery, GenericResponse<List<string>>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetAllSuppliersNamesHandler(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }
        public async Task<GenericResponse<List<string>>> Handle(GetAllSuppliersNamesQuery request, CancellationToken cancellationToken)
        {
            var suppliers = await _repositoryManager.Suppliers.GetAllAsync();

            var suppliersNames = await suppliers.
                Select(s => s.CompanyName)
                .Distinct()
                .ToListAsync();

            return Succeeded(suppliersNames);
        }
    }
}
