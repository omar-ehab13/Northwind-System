using Northwind.Application.Features.ProductsFeature.Suppliers.Queries.GetAllSuppliers;
using Northwind.Core.Entities;
using Northwind.Core.Extensions;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.FilterHandlers
{
    public class SupplierFilterHandler
    {
        private readonly IRepositoryManager _repositoryManager;

        public SupplierFilterHandler(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public async Task<IQueryable<Supplier>> FilterAsync(IQueryable<Supplier> suppliers, GetAllSuppliersQuery request)
        {

            suppliers = await suppliers.SearchAsync(request.Search, new string[] { nameof(Supplier.CompanyName) });

            suppliers = await suppliers.SortAsync(request.OrderBy, nameof(Supplier.CompanyName), typeof(Supplier));


            return suppliers;
        }
    }
}
