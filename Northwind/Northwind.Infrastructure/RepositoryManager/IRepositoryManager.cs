using Northwind.Infrastructure.Contracts;

namespace Northwind.Infrastructure.RepositoryManager
{
    public interface IRepositoryManager
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        ISupplierRepository Suppliers { get; }

        Task<int> SaveChangesAsync();
    }
}