using MediatR;
using Northwind.Core.Helpers.ResponseBase;

namespace Northwind.Application.Features.ProductsFeature.Suppliers.Commands.DeleteSupplier
{
    public class DeleteSupplierCommand : IRequest<GenericResponse<object>>
    {
        public DeleteSupplierCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }
}
