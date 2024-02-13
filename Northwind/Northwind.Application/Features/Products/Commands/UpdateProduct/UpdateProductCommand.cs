using MediatR;
using Northwind.Core.Entities;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand() : IRequest<GenericResponse<Product>>
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public string? CategoryName { get; set; }

        public string? Supplier { get; set; }

        public decimal? UnitPrice { get; set; }
    }
}
