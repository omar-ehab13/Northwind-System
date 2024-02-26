using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetAllSuppliersNames
{
    public class GetAllSuppliersNamesQuery : IRequest<GenericResponse<List<string>>>
    {
    }
}
