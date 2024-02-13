using MediatR;
using Northwind.Application.Features.Products.Queries._Helpers.DTOs;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.Products.Queries.GetProductById
{
    public record GetProductByIdQuery(int id) : IRequest<GenericResponse<GetProductByIdDto>>
    {
        public int Id => id;
    }
}
