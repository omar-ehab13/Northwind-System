using Northwind.Core.Entities;
using Northwind.Infrastructure.Base;

namespace Northwind.Infrastructure.Contracts
{
    public interface IProductRepository : IGenericRepository<Product>
    {
    }
}
