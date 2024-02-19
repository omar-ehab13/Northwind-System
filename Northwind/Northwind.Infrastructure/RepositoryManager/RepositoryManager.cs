using Microsoft.EntityFrameworkCore.Storage;
using Northwind.Core.Helpers.Logger;
using Northwind.Infrastructure.Contracts;
using Northwind.Infrastructure.Data;
using Northwind.Infrastructure.Repositories;

namespace Northwind.Infrastructure.RepositoryManager
{
    public class RepositoryManager : IRepositoryManager
    {
        #region Private Fields
        private readonly NorthwindContext context;
        private readonly ILoggerManager logger;

        private readonly Lazy<IProductRepository> _productRepository;
        private readonly Lazy<ICategoryRepository> _categoryRepository;
        private readonly Lazy<ISupplierRepository> _supplierRepository;
        #endregion

        #region Constructor
        public RepositoryManager(NorthwindContext context, ILoggerManager logger)
        {
            this.context = context;
            this.logger = logger;

            this._productRepository = new Lazy<IProductRepository>(() => new ProductRepository(context, logger));
            this._categoryRepository = new Lazy<ICategoryRepository>(() => new CategoryRepository(context, logger));
            this._supplierRepository = new Lazy<ISupplierRepository>(() => new SupplierRepository(context, logger));
        }
        #endregion

        #region Properties
        public IProductRepository Products => this._productRepository.Value;
        public ICategoryRepository Categories => this._categoryRepository.Value;
        public ISupplierRepository Suppliers => this._supplierRepository.Value;
        #endregion

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }

        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await context.Database.BeginTransactionAsync();
        }
    }
}
