using Northwind.Application.Features.ProductsFeature.Categories.Queries.GetAllCategories;
using Northwind.Core.Entities;
using Northwind.Core.Extensions;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.FilterHandlers
{
    public class CategoryFilterHandler
    {
        private readonly IRepositoryManager _repositoryManager;

        public CategoryFilterHandler(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }

        public async Task<IQueryable<Category>> FilterAsync(IQueryable<Category> categoris, GetAllCategoriesQuery request)
        {

            categoris = await categoris.SearchAsync(request.Search, new string[] { nameof(Category.CategoryName), nameof(Category.Description) });

            categoris = await categoris.SortAsync(request.OrderBy, nameof(Category.CategoryName), typeof(Category));


            return categoris;
        }
    }
}
