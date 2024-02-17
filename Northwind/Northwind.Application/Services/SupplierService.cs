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
    }
}
