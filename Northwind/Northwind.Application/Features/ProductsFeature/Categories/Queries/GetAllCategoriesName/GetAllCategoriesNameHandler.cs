using MediatR;
using Microsoft.EntityFrameworkCore;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Categories.Queries.GetAllCategoriesName
{
    public class GetAllCategoriesNameHandler :
        ResponseHandler, IRequestHandler<GetAllCategoriesNameQuery, GenericResponse<List<string>>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetAllCategoriesNameHandler(IRepositoryManager repositoryManager)
        {
            this._repositoryManager = repositoryManager;
        }
        public async Task<GenericResponse<List<string>>> Handle(GetAllCategoriesNameQuery request, CancellationToken cancellationToken)
        {
            var categories = await _repositoryManager.Categories.GetAllAsync();

            var categoriesName = await categories
                .Select(c => c.CategoryName)
                .Distinct()
                .ToListAsync();

            return Succeeded(categoriesName);
        }
    }
}
