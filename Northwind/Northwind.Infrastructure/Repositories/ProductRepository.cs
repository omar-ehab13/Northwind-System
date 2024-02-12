using Northwind.Core.Entities;
using Northwind.Core.Helpers.Logger;
using Northwind.Infrastructure.Base;
using Northwind.Infrastructure.Contracts;
using Northwind.Infrastructure.Data;

namespace Northwind.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(NorthwindContext context, ILoggerManager logger) :
            base(context, logger)
        {

        }
    }
}
