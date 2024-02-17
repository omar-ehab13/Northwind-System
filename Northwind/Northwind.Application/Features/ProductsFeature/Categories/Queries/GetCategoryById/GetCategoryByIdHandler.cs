using MediatR;
using Northwind.Application.Mappings.CategoriesMapping.Queries;
using Northwind.Core.Helpers.ResponseBase;
using Northwind.Infrastructure.RepositoryManager;

namespace Northwind.Application.Features.ProductsFeature.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdHandler :
        ResponseHandler, IRequestHandler<GetCategoryByIdQuery, GenericResponse<GetCategoryByIdDto>>
    {
        private readonly IRepositoryManager _repositoryManager;

        public GetCategoryByIdHandler(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<GenericResponse<GetCategoryByIdDto>> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            var category = await _repositoryManager.Categories.GetByIdAsync(request.Id);

            if (category is null) return NotFound<GetCategoryByIdDto>("Category Not Found");

            var result = category.MapToGetCategoryByIdDto();

            return Succeeded(result);
        }
    }
}
