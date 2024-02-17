using MediatR;
using Northwind.Core.Entities;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.ProductsFeature.Products.Commands.UpdateProduct
{
    public record UpdateProductCommand() : IRequest<GenericResponse<Product>>
    {
        public int Id { get; set; }

        public string ProductName { get; set; } = null!;

        public string? CategoryName { get; set; }

        public string? Supplier { get; set; }

        public string? QuantityPerUnit { get; set; }

        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }
    }
}
