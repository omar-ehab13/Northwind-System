using AutoMapper;
using MediatR;
using Northwind.Core.Entities;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Suppliers.Commands.AddSupplier
{
    public class AddSupplierHandler
        : ResponseHandler, IRequestHandler<AddSupplierCommand, GenericResponse<object>>
    {
        private readonly IRepositoryManager repositoryManager;
        private readonly IMapper mapper;

        public AddSupplierHandler(IRepositoryManager repositoryManager, IMapper mapper)
        {
            this.repositoryManager = repositoryManager;
            this.mapper = mapper;
        }

        public async Task<GenericResponse<object>> Handle(AddSupplierCommand request, CancellationToken cancellationToken)
        {
            var supplier = mapper.Map<Supplier>(request);

            if (!await repositoryManager.Suppliers.CreateAsync(supplier))
                return BadRequest<object>("Error during adding new supplier in DB");

            await repositoryManager.SaveChangesAsync();

            return Created<object>(supplier);
        }
    }
}
