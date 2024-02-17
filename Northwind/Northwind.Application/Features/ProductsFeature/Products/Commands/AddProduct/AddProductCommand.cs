using MediatR;
using Northwind.Core.Entities;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.ProductsFeature.Products.Commands.AddProduct
{
    public class AddProductCommand : IRequest<GenericResponse<Product>>
    {
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
