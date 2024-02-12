using Northwind.Core.Entities;
using Northwind.Core.Helpers.Logger;
using Northwind.Infrastructure.Base;
using Northwind.Infrastructure.Contracts;
using Northwind.Infrastructure.Data;

namespace Northwind.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(NorthwindContext context, ILoggerManager logger) :
            base(context, logger)
        {

        }
    }
}
