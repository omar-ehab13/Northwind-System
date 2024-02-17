using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.ProductsFeature.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(int id) : IRequest<GenericResponse<GetProductByIdDto>>
    {
        public int Id => id;
    }
}
