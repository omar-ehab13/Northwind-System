using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetSupplierById
{
    public class GetSupplierByIdQuery : IRequest<GenericResponse<GetSupplierByIdDto>>
    {
        public GetSupplierByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
