using Northwind.Application.Services.Contracts;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IRepositoryManager repositoryManager;

        public CategoryService(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<bool> IsNameExists(string categoryName)
        {
            var category = await repositoryManager.Categories
                .FindAsync(c => c.CategoryName.ToLower() == categoryName.ToLower(), trackChanges: false);

            return category != null;
        }
    }
}
