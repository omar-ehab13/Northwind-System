using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.Products.Commands.DeleteProduct
{
    public record DeletProductCommand(int id) : IRequest<GenericResponse<object>>
    {
        public int Id => id;
    }
}
