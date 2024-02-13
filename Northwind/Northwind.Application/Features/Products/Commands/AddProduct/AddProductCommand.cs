using MediatR;
using Northwind.Core.Entities;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.Products.Commands.AddProduct
{
    public class AddProductCommand : IRequest<GenericResponse<Product>>
    {
        public string ProductName { get; set; } = null!;

        public string? CategoryName { get; set; }

        public string? Supplier { get; set; }

        public decimal? UnitPrice { get; set; }
    }
}
