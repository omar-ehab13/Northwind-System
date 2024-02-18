using MediatR;
using Northwind.Application.Features.ProductsFeature.Categories.Queries.GetAllCategories.MetaData;
using Northwind.Application.FilterHandlers;
using Northwind.Application.Mappings.CategoriesMapping.Queries;
using Northwind.Core.Extensions;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesHandler : ResponseHandler,
        IRequestHandler<GetAllCategoriesQuery, GenericResponse<List<GetAllCategoriesDto>>>
    {
        private readonly IRepositoryManager repositoryManager;

        public GetAllCategoriesHandler(IRepositoryManager repositoryManager)
        {
            this.repositoryManager = repositoryManager;
        }

        public async Task<GenericResponse<List<GetAllCategoriesDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await repositoryManager.Categories.GetAllAsync(trackChanges: false);

            categories = await new CategoryFilterHandler(repositoryManager).FilterAsync(categories, request);

            var categoryMetaData = await CategoryMetaDataFactory.CreateCategoryMetaData(categories, request);

            categories = await categories.PaginateAsync(request.PageNumber, request.PageSize);

            var result = categories.Select(c => c.MapToGetAllCategoriesDto()).ToList();

            return Succeeded(result, categoryMetaData);
        }
    }
}
