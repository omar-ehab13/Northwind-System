using MediatR;
using Northwind.Core.Helpers.Pagination;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetAllSuppliers
{
    public class GetAllSuppliersQuery : PaginationParameters, IRequest<GenericResponse<List<GetAllSuppliersDto>>>
    {
    }
}
