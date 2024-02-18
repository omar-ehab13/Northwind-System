using Northwind.Application.Services.Contracts;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Services
{
    public class SupplierService : ISupplierService
    {
        private readonly IRepositoryManager repositoryManager;

        public SupplierService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<bool> IsNameExists(string companyName)
        {
            var supplier = await repositoryManager.Suppliers
                .FindAsync(s => s.CompanyName.ToLower() == companyName.ToLower(), trackChanges: false);

            return supplier != null;
        }

        public async Task<bool> IsNameExistsExcept(string companyName, int supplierId)
        {
            // I check in all company names except provided supplier (by supplier id)
            var supplier = await repositoryManager.Suppliers
                .FindAsync(s => s.CompanyName.ToLower() == companyName.ToLower() && s.SupplierId != supplierId, trackChanges: false);

            return supplier != null;
        }
    }
}
